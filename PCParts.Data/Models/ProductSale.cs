namespace PCParts.Data.Models;

public class ProductSale
{
    // Sale FK
    public int SaleId { get; set; }
    public Sale Sale { get; set; }

    // Product FK
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int Quantity { get; set; }
    public decimal UnitPriceAtSale { get; set; }
    public decimal TotalPrice => UnitPriceAtSale * Quantity;
}
