namespace eShopApp.Infrastructure.Products;

using eShopApp.Domain.Products;
using eShopApp.Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

internal class ProductsRepository(ApplicationDbContext productsContext) : Repository<Product>(productsContext), IProductsRepository
{
    public async Task<IEnumerable<Product>> GetAll()
    {
        var results = await _dbContext.Products.ToListAsync();
        return results;
    }

    public async Task<Product?> GetByGuid(Guid productId)
    {
        var result = await _dbContext.Products.SingleOrDefaultAsync(p => p.Guid == productId);
        return result;
    }
}
