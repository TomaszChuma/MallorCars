using MallorCar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MallorCar.Infrastructure.Persistence.EntityTypeConfigurations;

public class CarEntityTypeConfiguration : IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.HasKey(x => x.ModelId);
        builder.Property(x => x.ModelId)
            .IsRequired();

        builder.Property(x => x.ModelName)
            .IsRequired();

        builder.Property(x => x.ModelBaseDailyPrice)
            .IsRequired();

        builder.Property(x => x.ModelRange)
            .IsRequired();

        builder.Property(x => x.ModelNumOfSeats)
            .IsRequired();

        builder.Property(x => x.ModelAcceleration)
            .IsRequired();

        builder.Property(x => x.ModelTopSpeed)
            .IsRequired();

        builder.Property(x => x.ModelPhotoUrl)
            .IsRequired();
    }
}