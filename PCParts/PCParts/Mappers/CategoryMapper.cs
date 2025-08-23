using PCParts.Data.Models;
using PCParts.Data.Models.DTOs;

namespace PCParts.Mappers;

public static class CategoryMapper
{
    public static Category ToEntity(this CreateCategoryDto dto) => new Category { Name = dto.Name };

    public static CategoryDto ToDto(this Category category)
    {
        if (category == null)
            throw new ArgumentNullException(nameof(category));

        return new CategoryDto { Id = category.Id, Name = category.Name };
    }
}
