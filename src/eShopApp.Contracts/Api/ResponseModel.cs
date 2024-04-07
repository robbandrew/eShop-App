using System.Net;

namespace eShopApp.Contracts.Api;

public class ResponseModel<T>
{
    public T? Data { get; set; } = default(T);
    public string Message { get; set; } = string.Empty;
}