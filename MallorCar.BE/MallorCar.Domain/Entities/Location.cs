namespace MallorCar.Domain.Entities;

public class Location
{
    public Guid LocationId { get; set; }

    public string LocationName { get; set; } = default!;

    public virtual ICollection<Rental> BeginningsOfRentals { get; set; } = default!;

    public virtual ICollection<Rental> EndsOfRentals { get; set; } = default!;
}