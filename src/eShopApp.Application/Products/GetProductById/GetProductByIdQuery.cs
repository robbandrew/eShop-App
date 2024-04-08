namespace eShopApp.Application.Products.GetProductById;

using eShopApp.Contracts.Products;
using eShopApp.Domain.Products;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public record GetProductByIdQuery(int ProductId) : IRequest<ProductModel?>
{
}

internal class GetProductByIdQueryHandler(IProductsRepository productsRepository) : IRequestHandler<GetProductByIdQuery, ProductModel?>
{
    private readonly IProductsRepository _productsRepository = productsRepository;

    public async Task<ProductModel?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _productsRepository.GetById(request.ProductId);

        if (result == null) return null;

        return new ProductModel
        {
            Description = result.Description,
            ImageUrl = result.ImageUrl,
            Name = result.Name,
            ProductId = result.Guid
        };
    }
}
