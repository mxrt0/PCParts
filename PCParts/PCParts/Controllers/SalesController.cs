using Microsoft.AspNetCore.Mvc;
using PCParts.Data.Models.DTOs;
using PCParts.Exceptions;
using PCParts.Services.Contracts;

namespace PCParts.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalesController : ControllerBase
{
    private ISalesService _salesService;

    public SalesController(ISalesService salesService)
    {
        _salesService = salesService;
    }

    [HttpPost]
    public async Task<ActionResult<SaleDto>> CreateSale([FromBody] CreateSaleDto createSaleDto)
    {
        try
        {
            var saleDto = await _salesService.CreateSaleAsync(createSaleDto);
            return CreatedAtAction(nameof(GetSaleById), new { id = saleDto.Id }, saleDto);
        }
        catch (SaleCreationFailedException ex)
        {
            return BadRequest(new { errorMessage = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(500, new { errorMessage = "Internal server error!" });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SaleDto>> GetSaleById(int id)
    {
        try
        {
            var saleDto = await _salesService.GetSaleByIdAsync(id);
            return Ok(saleDto);
        }
        catch (SaleNotFoundException ex)
        {
            return NotFound(new { errorMessage = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(500, new { errorMessage = "Internal server error!" });
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<SaleDto>>> GetSales([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        try
        {
            var products = await _salesService.GetSalesAsync(pageNumber, pageSize);
            return Ok(products);
        }
        catch (Exception)
        {
            return StatusCode(500, new { errorMessage = "Internal server error!" });
        }
    }

}
