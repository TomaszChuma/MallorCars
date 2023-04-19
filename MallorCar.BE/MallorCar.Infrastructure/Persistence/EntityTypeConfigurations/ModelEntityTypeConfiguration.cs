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

        builder.HasData(new Model
        {
            ModelId = new Guid("a495611d-9a7a-48c0-9776-1f8bd92ba7d9"),
            ModelName = "X",
            ModelSubName = null,
            ModelBaseDailyPrice = 50,
            ModelRange = 560,
            ModelNumOfSeats = 7,
            ModelAcceleration = 3.8,
            ModelTopSpeed = 249,
            ModelPhotoUrl = "xnormal"
        }, new Model
        {
            ModelId = new Guid("8a11c1c2-2050-44f5-bfe2-856ce7810e86"),
            ModelName = "S",
            ModelSubName = "PLaid",
            ModelBaseDailyPrice = 20,
            ModelRange = 637,
            ModelNumOfSeats = 5,
            ModelAcceleration = 2,
            ModelTopSpeed = 322,
            ModelPhotoUrl = "splaid"
        }, new Model
        {
            ModelId = new Guid("4a03fd43-6c9f-4fb9-ba53-d09beb52c9fa"),
            ModelName = "Y",
            ModelSubName = "Performance",
            ModelBaseDailyPrice = 80,
            ModelRange = 488,
            ModelNumOfSeats = 5,
            ModelAcceleration = 3.5,
            ModelTopSpeed = 249,
            ModelPhotoUrl = "yperf"
        }, new Model
        {
            ModelId = new Guid("aae9a33e-f407-4d30-abd5-d1fdf9a2cc59"),
            ModelName = "Y",
            ModelSubName = "Long Range",
            ModelBaseDailyPrice = 66,
            ModelRange = 531,
            ModelNumOfSeats = 7,
            ModelAcceleration = 4.8,
            ModelTopSpeed = 217,
            ModelPhotoUrl = "ylong"
        }, new Model
        {
            ModelId = new Guid("d2c6aac2-03ed-4af6-b5c7-34a47ad5b048"),
            ModelName = "X",
            ModelSubName = "Plaid",
            ModelBaseDailyPrice = 69,
            ModelRange = 536,
            ModelNumOfSeats = 6,
            ModelAcceleration = 2.5,
            ModelTopSpeed = 262,
            ModelPhotoUrl = "xplaid"
        }, new Model
        {
            ModelId = new Guid("6ab8242c-395d-4a55-95c7-ab1acabb26a4"),
            ModelName = "S",
            ModelSubName = null,
            ModelBaseDailyPrice = 14,
            ModelRange = 651,
            ModelNumOfSeats = 5,
            ModelAcceleration = 3.1,
            ModelTopSpeed = 240,
            ModelPhotoUrl = "snormal"
        }, new Model
        {
            ModelId = new Guid("c720d513-4d1a-45e7-9a7a-b6f562768f0b"),
            ModelName = "3",
            ModelSubName = "Performance",
            ModelBaseDailyPrice = 56,
            ModelRange = 507,
            ModelNumOfSeats = 5,
            ModelAcceleration = 3.1,
            ModelTopSpeed = 261,
            ModelPhotoUrl = "3performance"
        }, new Model
        {
            ModelId = new Guid("06b2e583-3225-4ef2-92f7-ff1fb957405b"),
            ModelName = "3",
            ModelSubName = "RW Drive",
            ModelBaseDailyPrice = 52,
            ModelRange = 438,
            ModelNumOfSeats = 5,
            ModelAcceleration = 5.8,
            ModelTopSpeed = 225,
            ModelPhotoUrl = "3rear"
        });
    }
}