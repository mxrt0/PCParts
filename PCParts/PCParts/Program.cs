using Microsoft.EntityFrameworkCore;
using PCParts.Data.Context;
using PCParts.Services;
using PCParts.Services.Contracts;

namespace PCParts;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Configuration.AddUserSecrets<Program>();

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents()
            .AddInteractiveWebAssemblyComponents();
        builder.Services.AddScoped<IProductsService, ProductsService>();
        builder.Services.AddScoped<ICategoriesService, CategoriesService>();
        builder.Services.AddScoped<ISalesService, SalesService>();
        builder.Services.AddControllers();
        builder.Services.AddHttpClient();
        builder.Services.AddDbContext<PcPartsDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
        );

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.MapFallbackToFile("index.html");

        app.MapControllers();

        app.UseStaticFiles();
        app.UseAntiforgery();
        app.Run();
    }
}
