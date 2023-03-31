using MallorCar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MallorCar.Infrastructure.Persistence.EntityTypeConfigurations;

public class RentalEntityTypeConfiguration : IEntityTypeConfiguration<Rental>
{
    public void Configure(EntityTypeBuilder<Rental> builder)
    {
        builder.HasKey(x => x.RentalId);
        builder.Property(x => x.RentalId)
            .IsRequired();

        builder.Property(x => x.RentalStartDate)
            .IsRequired();

        builder.Property(x => x.RentalEndDate)
            .IsRequired();

        builder.Property(x => x.RentalCode)
            .IsRequired();

        builder.HasOne(x => x.RentalStartLocation)
            .WithMany(x => x.BeginningsOfRentals)
            .HasForeignKey(x => x.RentalStartLocationId)
            .IsRequired();

        builder.HasOne(x => x.RentalEndLocation)
            .WithMany(x => x.EndsOfRentals)
            .HasForeignKey(x => x.RentalEndLocationId)
            .IsRequired();

        builder.HasOne(x => x.Car)
            .WithMany(x => x.Rentals)
            .HasForeignKey(x => x.CarId)
            .IsRequired();

        builder.HasOne(x => x.Client)
            .WithMany(x => x.Rentals)
            .HasForeignKey(x => x.ClientId)
            .IsRequired();
    }
}