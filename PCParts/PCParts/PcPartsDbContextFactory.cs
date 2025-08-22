namespace PCParts;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PCParts.Data.Context;

public class PcPartsDbContextFactory : IDesignTimeDbContextFactory<PcPartsDbContext>
{
    public PcPartsDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PcPartsDbContext>();
        optionsBuilder.UseSqlite("Data Source=PCParts.db");
        return new PcPartsDbContext(optionsBuilder.Options);
    }
}

