namespace eShopApp.Domain.Base
{
    using System.Threading.Tasks;

    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity?> GetById(int productId);
        Task Remove(TEntity entity);
        Task<int> Add(TEntity entity);
        Task Update(TEntity entity);
}
}
