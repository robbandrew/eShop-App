namespace eShopApp.WebApi.Modules;

internal interface IModule
{
    IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
}
