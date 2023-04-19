using MallorCar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MallorCar.Infrastructure.Persistence.EntityTypeConfigurations;

public class ClientEntityTypeConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(x => x.ClientId);
        builder.Property(x => x.ClientId)
            .IsRequired();

        builder.Property(x => x.ClientFirstName)
            .IsRequired();

        builder.Property(x => x.ClientLastName)
            .IsRequired();

        builder.Property(x => x.ClientEmail)
            .IsRequired();

        builder.Property(x => x.ClientPhoneNumber)
            .IsRequired();

        builder.HasData(new Client
        {
            ClientId = new Guid("d7313719-e5c1-4bd4-b163-f79f13cccfa4"),
            ClientFirstName = "Tomasz",
            ClientLastName = "Chuma",
            ClientEmail = "tomaszchuma18@gmail.com",
            ClientPhoneNumber = "+48881441146",
        });
    }
}