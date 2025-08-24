using Microsoft.EntityFrameworkCore;
using PCParts.Data.Context;
using PCParts.Data.Models.DTOs;
using PCParts.Exceptions;
using PCParts.Mappers;
using PCParts.Services.Contracts;

namespace PCParts.Services;

public class ProductsService : IProductsService
{
    private PcPartsDbContext _dbContext;
    public ProductsService(PcPartsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ProductDto> AddProductAsync(CreateProductDto createProductDto)
    {
        try
        {
            var productToAdd = createProductDto.ToEntity();

            _dbContext.Products.Add(productToAdd);
            await _dbContext.SaveChangesAsync();

            await _dbContext.Entry(productToAdd).Reference(p => p.Category).LoadAsync();
            return productToAdd.ToDto();
        }
        catch (Exception)
        {
            throw new ProductSaveFailedException("Unable to save product!");
        }

    }

    public async Task<List<ProductDto>> GetProductsAsync(int pageNumber, int pageSize)
    {
        return await _dbContext.Products
            .Where(p => !p.IsDeleted)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Include(p => p.Category)
            .Select(p => p.ToDto()).ToListAsync();
    }

    public async Task<ProductDto> GetProductByIdAsync(int productId)
    {
        var product = await _dbContext.Products
        .Include(p => p.Category)
        .FirstOrDefaultAsync(p => p.Id == productId && !p.IsDeleted)
        ?? throw new ProductNotFoundException("Product not found!");

        return product.ToDto()!;
    }
}
