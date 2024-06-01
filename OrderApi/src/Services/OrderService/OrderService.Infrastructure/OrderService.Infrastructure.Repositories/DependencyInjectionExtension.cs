using Microsoft.Extensions.DependencyInjection;
using OrderService.Application.Services.Interfaces;

namespace OrderService.Infrastructure.Repositories;

public static class DependencyInjectionExtension
{
    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();
    }
}