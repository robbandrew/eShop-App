using System;
namespace eShopApp.Web.Api.Products
{
    public record ProductModel(string ItemCode, string Name, decimal Price, string Summary)
    {

    }
}