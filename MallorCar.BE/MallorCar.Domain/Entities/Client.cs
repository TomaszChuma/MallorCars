namespace MallorCar.Domain.Entities;

public class Client
{
    public Guid ClientId { get; set; }

    public string ClientFirstName { get; set; } = default!;

    public string ClientLastName { get; set; } = default!;

    public string ClientEmail { get; set; } = default!;

    public string ClientPhoneNumber { get; set; } = default!;

    public virtual ICollection<Rental> Rentals { get; set; } = default!;
}