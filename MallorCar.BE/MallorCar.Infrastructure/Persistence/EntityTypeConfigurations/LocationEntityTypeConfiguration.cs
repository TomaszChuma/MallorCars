using MallorCar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MallorCar.Infrastructure.Persistence.EntityTypeConfigurations;

public class LocationEntityTypeConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(x => x.LocationId);
        builder.Property(x => x.LocationId)
            .IsRequired();

        builder.Property(x => x.LocationName)
            .IsRequired();

        builder.HasData(new Location
        {
            LocationId = new Guid("e2858625-1c59-4144-9337-aa5855675027"),
            LocationName = "Palma City Center"
        }, new Location
        {
            LocationId = new Guid("ae34c296-26ab-4b14-b5c4-6b952fda024a"),
            LocationName = "Palma Airport"
        }, new Location
        {
            LocationId = new Guid("4adf23c4-981a-4764-9be5-84794f683de0"),
            LocationName = "Alcudia"
        }, new Location
        {
            LocationId = new Guid("d2c4813f-4cfe-4d79-8f88-9ceec20a9b7a"),
            LocationName = "Manacor"
        });
    }
}