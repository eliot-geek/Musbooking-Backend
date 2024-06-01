using Microsoft.Extensions.DependencyInjection;
using OrderService.Application.Services.Interfaces;
using OrderService.Application.Services.Mapping;

namespace OrderService.Application.Services;

public static class DependencyInjectionExtension
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingOrderProfile));
        services.AddScoped<IOrderService, Services.OrderService>();
    }
}