using eShopApp.Application;
using eShopApp.Infrastructure;
using eShopApp.Infrastructure.Base;
using eShopApp.WebApi.Modules;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddHttpContextAccessor();
    builder.Services.RegisterModules();

    builder.Services.AddSingleton(new ConnectionString(builder.Configuration.GetConnectionString("AppDb")!));

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("AppDb"));
    });
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.MapEndpoints();
    app.UseHttpsRedirection();
    app.Run();
}