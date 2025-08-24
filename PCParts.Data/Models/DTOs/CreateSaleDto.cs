namespace PCParts.Data.Models.DTOs;

public class CreateSaleDto
{
    public List<CreateProductSaleDto> Products { get; set; } = new();
}
