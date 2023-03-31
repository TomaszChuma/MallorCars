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
    }
}