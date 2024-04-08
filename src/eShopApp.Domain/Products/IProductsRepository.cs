using eShopApp.Domain.Base;

namespace eShopApp.Domain.Products;

public interface IProductsRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetAll();
    Task<Product?> GetByGuid(Guid productId);
}