namespace eShopApp.Contracts.Api;

public class RequestModel<T>
{
    public T? Data { get; set; } = default(T);
}