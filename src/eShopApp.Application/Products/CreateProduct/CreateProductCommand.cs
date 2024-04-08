namespace eShopApp.Application.Products.CreateProduct;

using eShopApp.Contracts.Products;
using eShopApp.Domain.Products;
using MediatR;

public record CreateProductCommand(string Name, string Description, string ImageUrl) : IRequest<CreateProductResponse>
{ }

internal class CreateProductCommandHandler(IProductsRepository repository)
    : IRequestHandler<CreateProductCommand, CreateProductResponse>
{
    private readonly IProductsRepository _repository = repository;

    public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = Product.CreateProduct(request.Name, request.Description, request.ImageUrl);

        var productId = await _repository.Add(product);

        return new CreateProductResponse
        {
            ProductId = product.Guid
        };
    }
}