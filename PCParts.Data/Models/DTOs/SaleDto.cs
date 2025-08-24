namespace PCParts.Data.Models.DTOs;

public class SaleDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public List<ProductSaleDto> Items { get; set; } = new();
    public decimal TotalPrice { get; set; }
}
