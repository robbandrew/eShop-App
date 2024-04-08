namespace eShopApp.Application.Products.GetProductByGuid
{
    using eShopApp.Contracts.Products;
    using eShopApp.Domain.Products;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public record GetProductByGuidQuery(Guid ProductId) : IRequest<ProductModel?>
    {
    }

    internal class GetProductByGuidQueryHandler : IRequestHandler<GetProductByGuidQuery, ProductModel?>
    {
        private readonly IProductsRepository _repository;

        public GetProductByGuidQueryHandler(IProductsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductModel?> Handle(GetProductByGuidQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByGuid(request.ProductId);
            if (result == null) return null;

            return new ProductModel
            {
                Description = result.Description,
                ImageUrl = result.ImageUrl,
                Name = result.Name,
                ProductId = request.ProductId
            };
        }
    }
}
