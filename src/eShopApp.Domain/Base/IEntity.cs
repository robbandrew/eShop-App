namespace eShopApp.Domain.Base;

public interface IEntity
{
    int Id { get; init; }
}

public abstract class Entity : IEntity
{
    public int Id { get; init; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
}