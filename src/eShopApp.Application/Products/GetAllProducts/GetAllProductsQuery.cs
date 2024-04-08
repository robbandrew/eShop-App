namespace eShopApp.Application.Products.GetAllProducts
{
    using eShopApp.Contracts.Products;
    using eShopApp.Domain.Products;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public record GetAllProductsQuery() : IRequest<IEnumerable<ProductModel>>
    {
    }

    internal class GetAllProductQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductModel>>
    {
        private readonly IProductsRepository _productsRepository;

        public GetAllProductQueryHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<IEnumerable<ProductModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await _productsRepository.GetAll();

            return result.Select(x => new ProductModel
            {
                ImageUrl = x.ImageUrl,
                Name = x.Name,
                Description = x.Description,
                ProductId = x.Guid
            });
        }
    }
}
