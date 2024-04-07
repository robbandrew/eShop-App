using System.Xml;
using eShopApp.Domain.Base;

namespace eShopApp.Domain.Products;

public class Product : Entity, IGuid
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public Guid Guid { get; init; }

    public static Product CreateProduct(string name, string description, string imageUrl)
    {
        return new Product
        {
            Name = name,
            Description = description,
            ImageUrl = imageUrl,
            Guid = new Guid()
        };
    }
}