namespace eShopApp.WebApi.Endpoints.Products;

using eShopApp.Application.Products.GetAllProducts;
using eShopApp.Application.Products.GetProductByGuid;
using eShopApp.Application.Products.CreateProduct;
using eShopApp.Contracts.Api;
using eShopApp.Contracts.Products;
using eShopApp.WebApi.Modules;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

public class ProductEndpoints : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/products");

        group.WithTags("Products").WithOpenApi();

        group.MapGet("/", async (ISender sender) =>
            await GetProducts(sender))
                    .Produces<ResponseModel<ProductModel>>()
                    .WithDisplayName("Get Products")
                    .WithDescription("Returns all products");

        group.MapGet("/{productId:Guid}", async (ISender sender, Guid productId) => 
            await GetProductByGuid(sender, productId))
                    .Produces<ResponseModel<ProductModel>>()
                    .WithDisplayName("Get Product")
                    .WithDescription("Returns a product for a matching Id (Guid)");

        group.MapPost("/", async (ISender sender, [FromBody] CreateProductRequest request) =>
            await AddProduct(sender, request))
                    .Accepts<CreateProductRequest>("application/json")
                    .Produces<ResponseModel<CreateProductResponse>>(contentType: "application/json")
                    .WithDisplayName("Add Product")
                    .WithDescription("Adds a product to the products catalogue");

        return endpoints;
    }

    private static async Task<IResult> GetProductByGuid(ISender sender, Guid productId)
    {
        if (productId == Guid.Empty) return Results.BadRequest("Invalid Product Id");

        var queryResult = await sender.Send(new GetProductByGuidQuery(productId));
        if (queryResult == null) return Results.NotFound($"Product not found for Id ({productId})");

        var responseModel = new ResponseModel<ProductModel>()
        {
            NumberOfRecords = 1,
            Data = queryResult,
        };

        return Results.Ok(responseModel);
    }

    private static async Task<IResult> GetProducts(ISender sender)
    {
        var queryResult = await sender.Send(new GetAllProductsQuery());
        var responseModel = new ResponseModel<IEnumerable<ProductModel>>()
        {
            NumberOfRecords = queryResult.Count(),
            Data = queryResult
        };

        return Results.Ok(responseModel);
    }

    private static async Task<IResult> AddProduct(ISender sender, CreateProductRequest request)
    {
        if (request == null) return Results.BadRequest("Request Data Cannot Be Null");

        var createCommand = new CreateProductCommand(request.Name,
                                                     request.Description,
                                                     request.ImageUrl);

        var result = await sender.Send(createCommand);
        var createProductResponse = new CreateProductResponse { ProductId = result.ProductId };
        var responseModel = new ResponseModel<CreateProductResponse>() { Message = "Product Added Successfully", Data = createProductResponse };

        return Results.Created($"/products/{result.ProductId}", responseModel);
    }
}