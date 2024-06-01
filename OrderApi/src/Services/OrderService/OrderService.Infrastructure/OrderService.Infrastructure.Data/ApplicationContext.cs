using Microsoft.EntityFrameworkCore;
using Npgsql;
using OrderService.Domain.Entities;
using OrderService.Infrastructure.Data.EntityConfiguration;

namespace OrderService.Infrastructure.Data;

public class ApplicationContext : DbContext
{
    public DbSet<Order> Orders { get; set; } = null!;

    public ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    public async Task MigrateAsync()
    {
        await Database.MigrateAsync();
        if (Database.GetDbConnection() is NpgsqlConnection npgsqlConnection)
        {
            await npgsqlConnection.OpenAsync();
            try
            {
                npgsqlConnection.ReloadTypes();
            }
            finally
            {
                await npgsqlConnection.CloseAsync();
            }
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new EquipmentConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}