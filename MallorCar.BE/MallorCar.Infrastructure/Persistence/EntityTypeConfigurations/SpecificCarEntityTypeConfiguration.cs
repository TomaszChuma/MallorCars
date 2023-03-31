using MallorCar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MallorCar.Infrastructure.Persistence.EntityTypeConfigurations;

public class SpecificCarEntityTypeConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(x => x.CarId);
        builder.Property(x => x.CarId)
            .IsRequired();

        builder.Property(x => x.CarRegNumber)
            .IsRequired();

        builder.Property(x => x.ModelId)
            .IsRequired();

        builder.HasOne(x => x.Model)
            .WithMany(x => x.Cars);
    }
}