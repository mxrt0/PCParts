using PCParts.Data.Models.DTOs;

namespace PCParts.Services.Contracts;

public interface ICategoriesService
{
    Task<CategoryDto> AddCategoryAsync(CreateCategoryDto createDto);
    Task<List<CategoryDto>> GetAllCategoriesAsync();
    Task<CategoryDto> GetCategoryByIdAsync(int id);
}
