namespace eShopApp.Contracts.Products;

using System.ComponentModel.DataAnnotations;

public class CreateProductRequest
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    [Required]
    public string ImageUrl { get; set; } = string.Empty;
}

public class CreateProductResponse
{
    public int ProductId { get; set; }
}