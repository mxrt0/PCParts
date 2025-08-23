namespace PCParts.Data.Models;

public class Product
{
    public Product() { }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsOutOfStock => Quantity <= 0;

    // EF Core Foreign Key Category One-To-Many Relation
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    // EF Core Foreign Key Product Sales Many-To-Many Relation
    public ICollection<ProductSale> ProductSales { get; set; } = new List<ProductSale>();
}
