using PCParts.Data.Models;
using PCParts.Data.Models.DTOs;

namespace PCParts.Mappers;

public static class ProductSaleMapper
{
    public static ProductSaleDto ToDto(this ProductSale sale)
    {
        return new ProductSaleDto
        {
            ProductName = sale.Product.Name,
            Quantity = sale.Quantity,
            UnitPriceAtSale = sale.UnitPriceAtSale,
            TotalPrice = sale.TotalPrice
        };
    }

    public static SaleDto ToDto(this Sale sale)
    {
        return new SaleDto
        {
            Id = sale.Id,
            Date = sale.Date,
            Items = sale.ProductSales.Select(ps => ps.ToDto()).ToList(),
            TotalPrice = sale.ProductSales.Sum(ps => ps.TotalPrice)
        };
    }
}
