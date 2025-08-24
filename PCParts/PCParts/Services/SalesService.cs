using Microsoft.EntityFrameworkCore;
using PCParts.Data.Context;
using PCParts.Data.Models;
using PCParts.Data.Models.DTOs;
using PCParts.Exceptions;
using PCParts.Mappers;
using PCParts.Services.Contracts;

namespace PCParts.Services;

public class SalesService : ISalesService
{
    private PcPartsDbContext _dbContext;

    public SalesService(PcPartsDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<SaleDto> CreateSaleAsync(CreateSaleDto createDto)
    {
        try
        {
            var sale = new Sale
            {
                Date = DateTime.UtcNow,
                ProductSales = new List<ProductSale>()
            };

            foreach (var product in createDto.Products)
            {
                var productEntity = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == product.ProductId && !p.IsDeleted);

                if (productEntity is null)
                {
                    throw new ProductNotFoundException($"Product with id {product.ProductId} not found.");
                }
                if (productEntity.IsOutOfStock)
                {
                    throw new InvalidOperationException($"{productEntity.Name} is out of stock!");
                }
                if (productEntity.Quantity < product.Quantity)
                {
                    throw new InvalidOperationException($"Not enough stock for {productEntity.Name}!");
                }
                var productSale = new ProductSale { ProductId = productEntity.Id, Quantity = product.Quantity, UnitPriceAtSale = productEntity.Price };
                sale.ProductSales.Add(productSale);
                productEntity.Quantity -= product.Quantity;
            }

            _dbContext.Sales.Add(sale);
            await _dbContext.SaveChangesAsync();

            foreach (var ps in sale.ProductSales)
            {
                await _dbContext.Entry(ps)
                    .Reference(p => p.Product)
                    .LoadAsync();
            }
            return sale.ToDto();
        }
        catch (InvalidOperationException ex)
        {
            throw new SaleCreationFailedException(ex.Message);
        }
        catch (Exception)
        {
            throw new SaleCreationFailedException("Unable to create sale!");
        }

    }

    public async Task<SaleDto> GetSaleByIdAsync(int id)
    {
        var sale = await _dbContext.Sales.FirstOrDefaultAsync(s => s.Id == id)
            ?? throw new SaleNotFoundException("Unable to find sale!");
        return sale.ToDto();
    }

    public async Task<List<SaleDto>> GetSalesAsync(int pageNumber, int pageSize)
    {
        var sales = await _dbContext.Sales
            .Include(s => s.ProductSales)
            .ThenInclude(ps => ps.Product)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize).ToListAsync();

        return sales.Select(s => s.ToDto()).ToList();
    }
}
