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

                var productSale = new ProductSale { ProductId = productEntity.Id, Quantity = product.Quantity, UnitPriceAtSale = productEntity.Price };
                sale.ProductSales.Add(productSale);
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
}
