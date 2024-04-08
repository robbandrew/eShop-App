namespace eShopApp.Infrastructure;

using eShopApp.Domain.Products;
using eShopApp.Infrastructure.Products;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddScoped<IProductsRepository, ProductsRepository>();
        return services;
    }
}
