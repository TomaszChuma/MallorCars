namespace MallorCar.Domain.Entities;

public class Rental
{
    public Guid RentalId { get; set; }

    public DateTime RentalStartDate { get; set; }
    public DateTime RentalEndDate { get; set; }

    public string RentalCode { get; set; } = default!;

    public Guid RentalStartLocationId { get; set; }
    public Location RentalStartLocation { get; set; } = default!;

    public Guid RentalEndLocationId { get; set; }
    public Location RentalEndLocation { get; set; } = default!;

    public Guid CarId { get; set; }
    public Car Car { get; set; } = default!;

    public Guid ClientId { get; set; }
    public Client Client { get; set; } = default!;
}