using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PCParts.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "CPUs" },
                    { 2, "GPUs" },
                    { 3, "Motherboards" },
                    { 4, "RAM" },
                    { 5, "Storage" },
                    { 6, "Power Supplies" },
                    { 7, "Cases" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "IsDeleted", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "16-Core 5.4GHz CPU", false, "Intel Core i7-13700K", 700.00m, 15 },
                    { 2, 1, "8-Core 5.0GHz CPU with 3D V-Cache", false, "AMD Ryzen 7 7800X3D", 668.99m, 12 },
                    { 3, 2, "12GB GDDR6X Graphics Card", false, "NVIDIA GeForce RTX 4070 Ti", 1616.99m, 8 },
                    { 4, 2, "20GB GDDR6 Graphics Card", false, "AMD Radeon RX 7900 XT", 1645.99m, 6 },
                    { 5, 3, "ATX Motherboard for Intel 13th Gen", false, "ASUS ROG Strix Z790-E", 379.99m, 10 },
                    { 6, 3, "AM5 Motherboard for Ryzen 7000", false, "MSI B650 Tomahawk WiFi", 239.99m, 14 },
                    { 7, 4, "2x16GB 6000MHz CL36 RAM Kit", false, "Corsair Vengeance DDR5 32GB", 169.99m, 20 },
                    { 8, 4, "2x32GB 6400MHz CL32 RAM Kit", false, "G.Skill Trident Z5 DDR5 64GB", 349.99m, 10 },
                    { 9, 5, "Gen 4 NVMe SSD, up to 7450 MB/s", false, "Samsung 990 Pro 2TB NVMe", 229.99m, 18 },
                    { 10, 5, "Gen 4 NVMe SSD, up to 7300 MB/s", false, "WD Black SN850X 1TB", 129.99m, 22 },
                    { 11, 6, "850W 80+ Gold Fully Modular PSU", false, "Corsair RM850x", 149.99m, 16 },
                    { 12, 6, "1000W 80+ Titanium Fully Modular PSU", false, "Seasonic Prime TX-1000", 289.99m, 7 },
                    { 13, 7, "ATX Mid Tower Case with Tempered Glass", false, "Lian Li PC-O11 Dynamic", 139.99m, 9 },
                    { 14, 7, "ATX Mid Tower Case with High Airflow", false, "Fractal Design Meshify 2", 169.99m, 11 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
