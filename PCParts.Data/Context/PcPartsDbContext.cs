using Microsoft.EntityFrameworkCore;
using PCParts.Data.Models;

namespace PCParts.Data.Context;

public class PcPartsDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<ProductSale> ProductSales { get; set; }

    public PcPartsDbContext(DbContextOptions<PcPartsDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<Category>().HasData(
        new { Id = 1, Name = "CPUs" },
        new { Id = 2, Name = "GPUs" },
        new { Id = 3, Name = "Motherboards" },
        new { Id = 4, Name = "RAM" },
        new { Id = 5, Name = "Storage" },
        new { Id = 6, Name = "Power Supplies" },
        new { Id = 7, Name = "Cases" }
    );

        modelBuilder.Entity<ProductSale>()
            .HasKey(ps => new { ps.SaleId, ps.ProductId });

        modelBuilder.Entity<ProductSale>()
            .HasOne(ps => ps.Sale)
            .WithMany(s => s.ProductSales)
            .HasForeignKey(ps => ps.SaleId);

        modelBuilder.Entity<ProductSale>()
            .HasOne(ps => ps.Product)
            .WithMany(p => p.ProductSales)
            .HasForeignKey(ps => ps.ProductId);

        modelBuilder.Entity<Product>().HasData(
        new Product { Id = 1, Name = "Intel Core i7-13700K", Description = "16-Core 5.4GHz CPU", Price = 700.00m, Quantity = 15, IsDeleted = false, CategoryId = 1 },
        new Product { Id = 2, Name = "AMD Ryzen 7 7800X3D", Description = "8-Core 5.0GHz CPU with 3D V-Cache", Price = 668.99m, Quantity = 12, IsDeleted = false, CategoryId = 1 },

        new Product { Id = 3, Name = "NVIDIA GeForce RTX 4070 Ti", Description = "12GB GDDR6X Graphics Card", Price = 1616.99m, Quantity = 8, IsDeleted = false, CategoryId = 2 },
        new Product { Id = 4, Name = "AMD Radeon RX 7900 XT", Description = "20GB GDDR6 Graphics Card", Price = 1645.99m, Quantity = 6, IsDeleted = false, CategoryId = 2 },

        new Product { Id = 5, Name = "ASUS ROG Strix Z790-E", Description = "ATX Motherboard for Intel 13th Gen", Price = 379.99m, Quantity = 10, IsDeleted = false, CategoryId = 3 },
        new Product { Id = 6, Name = "MSI B650 Tomahawk WiFi", Description = "AM5 Motherboard for Ryzen 7000", Price = 239.99m, Quantity = 14, IsDeleted = false, CategoryId = 3 },

        new Product { Id = 7, Name = "Corsair Vengeance DDR5 32GB", Description = "2x16GB 6000MHz CL36 RAM Kit", Price = 169.99m, Quantity = 20, IsDeleted = false, CategoryId = 4 },
        new Product { Id = 8, Name = "G.Skill Trident Z5 DDR5 64GB", Description = "2x32GB 6400MHz CL32 RAM Kit", Price = 349.99m, Quantity = 10, IsDeleted = false, CategoryId = 4 },

        new Product { Id = 9, Name = "Samsung 990 Pro 2TB NVMe", Description = "Gen 4 NVMe SSD, up to 7450 MB/s", Price = 229.99m, Quantity = 18, IsDeleted = false, CategoryId = 5 },
        new Product { Id = 10, Name = "WD Black SN850X 1TB", Description = "Gen 4 NVMe SSD, up to 7300 MB/s", Price = 129.99m, Quantity = 22, IsDeleted = false, CategoryId = 5 },

        new Product { Id = 11, Name = "Corsair RM850x", Description = "850W 80+ Gold Fully Modular PSU", Price = 149.99m, Quantity = 16, IsDeleted = false, CategoryId = 6 },
        new Product { Id = 12, Name = "Seasonic Prime TX-1000", Description = "1000W 80+ Titanium Fully Modular PSU", Price = 289.99m, Quantity = 7, IsDeleted = false, CategoryId = 6 },

        new Product { Id = 13, Name = "Lian Li PC-O11 Dynamic", Description = "ATX Mid Tower Case with Tempered Glass", Price = 139.99m, Quantity = 9, IsDeleted = false, CategoryId = 7 },
        new Product { Id = 14, Name = "Fractal Design Meshify 2", Description = "ATX Mid Tower Case with High Airflow", Price = 169.99m, Quantity = 11, IsDeleted = false, CategoryId = 7 });

        base.OnModelCreating(modelBuilder);
    }
}
