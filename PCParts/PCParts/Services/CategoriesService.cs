using Microsoft.EntityFrameworkCore;
using PCParts.Data.Context;
using PCParts.Data.Models.DTOs;
using PCParts.Exceptions;
using PCParts.Mappers;
using PCParts.Services.Contracts;

namespace PCParts.Services;

public class CategoriesService : ICategoriesService
{
    private PcPartsDbContext _dbContext;
    public CategoriesService(PcPartsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CategoryDto> AddCategoryAsync(CreateCategoryDto createDto)
    {
        try
        {
            var categoryToAdd = createDto.ToEntity();
            _dbContext.Categories.Add(categoryToAdd);
            await _dbContext.SaveChangesAsync();
            var dto = categoryToAdd.ToDto();
            return dto;
        }
        catch (Exception)
        {
            throw new CategorySaveFailedException("Unable to save category!");
        }

    }

    public async Task<List<CategoryDto>> GetAllCategoriesAsync()
    {
        try
        {
            return await _dbContext.Categories.Select(c => c.ToDto()).ToListAsync();
        }
        catch (Exception)
        {
            throw new CategoryNotFoundException("No categories found!");
        }
    }

    public async Task<CategoryDto> GetCategoryByIdAsync(int id)
    {
        var category = await _dbContext.Categories.FirstOrDefaultAsync(category => category.Id == id)
            ?? throw new CategoryNotFoundException("Category not found!");
        return category.ToDto();
    }
}
