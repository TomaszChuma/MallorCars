namespace MallorCar.Controllers.Requests.Rental;

public class CreateRentalRequest
{
    public Guid ModelId { get; set; }
    
    public Guid RentalStartLocationId { get; set; }
    
    public Guid RentalEndLocationId { get; set; }
    
    public DateTime RentalStartDate { get; set; }
    
    public DateTime RentalEndDate { get; set; }

    public Guid ClientId { get; set; }
}