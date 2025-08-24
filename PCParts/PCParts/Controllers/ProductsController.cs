using Microsoft.AspNetCore.Mvc;
using PCParts.Data.Models.DTOs;
using PCParts.Exceptions;
using PCParts.Services.Contracts;

namespace PCParts.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private IProductsService _productsService;
    public ProductsController(IProductsService productsService)
    {
        _productsService = productsService;
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> AddProducts([FromBody] CreateProductDto createProductDto)
    {
        try
        {
            var productDto = await _productsService.AddProductAsync(createProductDto);
            return CreatedAtAction(nameof(GetProductById), new { id = productDto.Id }, productDto);
        }
        catch (ProductSaveFailedException ex)
        {
            return BadRequest(new { errorMessage = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(500, new { errorMessage = "Internal server error!" });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetProductById(int id)
    {
        try
        {
            var product = await _productsService.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }
        catch (ProductNotFoundException ex)
        {
            return NotFound(new { errorMessage = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(500, new { errorMessage = "Internal server error!" });
        }

    }
}
