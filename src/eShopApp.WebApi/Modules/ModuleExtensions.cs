namespace eShopApp.WebApi.Modules;

internal static class ModuleExtensions
{
    private static readonly List<IModule> _registeredModules = new();

    public static IServiceCollection RegisterModules(this IServiceCollection services)
    {
        var modules = DiscoverModules();
        foreach (var module in modules) _registeredModules.Add(module);

        return services;
    }

    public static WebApplication MapEndpoints(this WebApplication application)
    {
        foreach (var module in _registeredModules) module.MapEndpoints(application);

        return application;
    }

    private static IEnumerable<IModule> DiscoverModules()
    {
        return typeof(IModule).Assembly
            .GetTypes()
            .Where(p => p.IsClass & p.IsAssignableTo(typeof(IModule)))
            .Select(Activator.CreateInstance)
            .Cast<IModule>();
    }
}
