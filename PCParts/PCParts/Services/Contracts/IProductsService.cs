using PCParts.Data.Models.DTOs;
namespace PCParts.Services.Contracts;

public interface IProductsService
{
    Task<ProductDto> AddProductAsync(CreateProductDto createDto);
    Task<ProductDto> GetProductByIdAsync(int productId);
    Task<List<ProductDto>> GetProductsAsync(int pageNumber, int pageSize);
}
