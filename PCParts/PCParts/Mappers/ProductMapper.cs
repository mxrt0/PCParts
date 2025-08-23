using PCParts.Data.Models;
using PCParts.Data.Models.DTOs;
namespace PCParts.Mappers;

public static class ProductMapper
{
    public static Product ToEntity(this CreateProductDto createDto)
    {
        var product = new Product
        {
            Name = createDto.Name,
            Description = createDto.Description,
            Price = createDto.Price,
            Quantity = createDto.Quantity,
            CategoryId = createDto.CategoryId,
            IsDeleted = false
        };
        return product;
    }

    public static ProductDto ToDto(this Product product)
    {
        var dto = new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Quantity = product.Quantity,
            CategoryName = product.Category?.Name ?? "Unknown"
        };
        return dto;
    }
}
