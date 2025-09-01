using Microsoft.AspNetCore.Mvc;
using PCParts.Data.Models.DTOs;
using PCParts.Exceptions;
using PCParts.Services.Contracts;

namespace PCParts.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private ICategoriesService _categoriesService;

    public CategoriesController(ICategoriesService categoriesService)
    {
        _categoriesService = categoriesService;
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDto>> AddCategory([FromBody] CreateCategoryDto createDto)
    {
        try
        {
            var categoryDto = await _categoriesService.AddCategoryAsync(createDto);
            return CreatedAtAction(nameof(GetCategoryById), new { id = categoryDto.Id }, categoryDto);
        }
        catch (CategorySaveFailedException ex)
        {
            return BadRequest(new { errorMessage = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>> GetCategoryById(int id)
    {
        try
        {
            var categoryDto = await _categoriesService.GetCategoryByIdAsync(id);
            return Ok(categoryDto);
        }
        catch (CategoryNotFoundException ex)
        {
            return NotFound(new { errorMessage = ex.Message });
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<CategoryDto>>> GetAllCategories()
    {
        try
        {
            var categories = await _categoriesService.GetAllCategoriesAsync();
            return Ok(categories);
        }
        catch (CategoryNotFoundException ex)
        {
            return NotFound(new { errorMessage = ex.Message });
        }
    }
}
