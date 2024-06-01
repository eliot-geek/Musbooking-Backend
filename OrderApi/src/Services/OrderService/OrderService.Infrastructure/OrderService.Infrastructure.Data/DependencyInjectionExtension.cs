using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OrderService.Infrastructure.Data;

public static class DependencyInjectionExtension
{
    public static void ConfigureApplicationContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddNpgsql<ApplicationContext>(configuration.GetConnectionString("DefaultConnection") ??
                                               throw new ArgumentException("Строка подключения к бд не указана"));
    }
}