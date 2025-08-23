﻿namespace PCParts.Data.Models.DTOs;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string CategoryName { get; set; }
    public bool IsAvailable => Quantity > 0;
}
