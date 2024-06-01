using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.Domain.Entities;

namespace OrderService.Infrastructure.Data.EntityConfiguration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("orders")
            .HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("id").ValueGeneratedNever();

        builder.Property(p => p.Description)
            .HasColumnName("description")
            .IsRequired();

        builder.Property(p => p.Price)
            .HasColumnName("price")
            .IsRequired();

        builder.Property(p => p.UpdatedAt)
            .HasColumnName("updated_at")
            .HasColumnType("date");

        builder.OwnsOne(p => p.CreatedDate, fullName =>
        {
            fullName.Property(p => p.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("date")
                .IsRequired();
        });

        builder.HasMany(p => p.Equipments)
            .WithOne()
            .HasForeignKey("order_id")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}