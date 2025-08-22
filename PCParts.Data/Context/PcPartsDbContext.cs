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

        base.OnModelCreating(modelBuilder);
    }
}
