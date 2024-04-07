namespace eShopApp.Web.Api.Products
{
    using Application.Products.Commands;
    using Contracts.Api;
    using Contracts.Products;
    using Domain.Base;
    using MediatR;
    using Microsoft.AspNetCore.Http.HttpResults;

    public static class ProductEndpoints
    {
        public static WebApplication RegisterProductEndpoints(this WebApplication app)
        {
            app.MapGroup("/products").WithTags("Products");

            app.MapPost("/addproduct", async (RequestModel<CreateProductRequest> request, ISender sender) 
                => await CreateProduct(request, sender)
            ).Produces<CreateProductRequest>();
            
            return app;
        }

        private static async Task<IResult> CreateProduct(RequestModel<CreateProductRequest> request, ISender sender)
        {
            if (request.Data == null) 
                return Results.BadRequest("Create product request can not be null");

            var result = await sender.Send(new CreateProductCommand
            (
                request.Data.Name,
                request.Data.Description,
                request.Data.ImageUrl
            ));
            
            var responseModel =  new ResponseModel<CreateProductResponse>
            {
                Data = new CreateProductResponse { ProductId = result.ProductId },
                Message = "Product Successfully Created"
            };

            return Results.Created(new Uri($"/products/{result.ProductId}"), responseModel);
        }
    }
}

