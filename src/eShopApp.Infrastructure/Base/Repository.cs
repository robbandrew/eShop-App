namespace eShopApp.Infrastructure.Base
{
    using eShopApp.Domain.Base;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    internal abstract class Repository<TEntity>(ApplicationDbContext productsContext) : IRepository<TEntity>
        where TEntity : Entity
    {
        protected readonly ApplicationDbContext _dbContext = productsContext;

        public async Task<TEntity?> GetById(int productId)
        {
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(i => i.Id == productId);
        }

        public async Task Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Add(TEntity entity)
        {
            entity.DateCreated = DateTime.Now;
            _dbContext.Set<TEntity>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task Update(TEntity entity)
        {
            entity.DateModified = DateTime.Now;
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
