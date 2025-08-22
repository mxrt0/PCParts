namespace PCParts.Data.Models;

public class Sale
{
    public int Id { get; set; }
    public DateTime Date { get; set; }

    public ICollection<ProductSale> ProductSales { get; set; } = new List<ProductSale>();
}
