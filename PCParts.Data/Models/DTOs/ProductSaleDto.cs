namespace PCParts.Data.Models.DTOs;

public class ProductSaleDto
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPriceAtSale { get; set; }
    public decimal TotalPrice { get; set; }

}
