using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.Domain.Entities;

namespace OrderService.Infrastructure.Data.EntityConfiguration;

public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
{
    public void Configure(EntityTypeBuilder<Equipment> builder)
    {
        builder.ToTable("equipment")
            .HasKey(experience => experience.Id);

        builder.Property(w => w.Id)
            .HasColumnName("id").ValueGeneratedNever();

        builder.Property(experience => experience.Amount)
            .HasColumnName("amount")
            .IsRequired();

        builder.Property(experience => experience.Price)
            .HasColumnName("price")
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(experience => experience.Name)
            .HasColumnName("name")
            .IsRequired();

        builder.HasIndex(c => c.Name)
            .IsUnique();
    }
}