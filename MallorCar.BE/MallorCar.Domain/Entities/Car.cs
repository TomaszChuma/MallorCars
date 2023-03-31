namespace MallorCar.Domain.Entities;

public class Car
{
    public Guid CarId { get; set; }

    public string CarRegNumber { get; set; } = default!;
    
    public Guid ModelId { get; set; }
    public virtual Model Model { get; set; } = default!;

    public virtual ICollection<Rental> Rentals { get; set; } = default!;
}