using PCParts.Data.Models.DTOs;

namespace PCParts.Services.Contracts;

public interface ISalesService
{
    Task<SaleDto> CreateSaleAsync(CreateSaleDto createDto);
    Task<SaleDto> GetSaleByIdAsync(int id);
    Task<List<SaleDto>> GetSalesAsync(int pageNumber, int pageSize);
}
