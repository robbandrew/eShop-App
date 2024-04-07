namespace eShopApp.Domain.Base;

public interface IRepository<T> where T : IEntity
{
    Task<int> Insert(T entity);
    Task<T> Update(T entity);
    Task<bool> Delete(T entity);
    Task<T> GetById { get; set; }
    Task<T> GetByGuid { get; set; }
}