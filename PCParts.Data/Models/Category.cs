namespace PCParts.Data.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    // EF Core Foreign Key One-To-Many Relation
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
