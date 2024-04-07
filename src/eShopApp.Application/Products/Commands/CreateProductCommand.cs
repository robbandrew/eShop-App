using eShopApp.Domain.Products;

namespace eShopApp.Application.Products.Commands;
using Contracts.Products;
using MediatR;

public record CreateProductCommand(string Name, string Description, string ImageUrl) : IRequest<CreateProductResponse>
{ }

internal class CreateProductCommandHandler(IProductRepository repository)
    : IRequestHandler<CreateProductCommand, CreateProductResponse>
{
    private readonly IProductRepository _repository = repository;

    public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = Product.CreateProduct(request.Name, request.Description, request.ImageUrl);

        var productId = await _repository.Insert(product);
        
        return new CreateProductResponse
        {
            ProductId = productId
        };
    }
}