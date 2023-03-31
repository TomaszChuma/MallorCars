namespace MallorCar.Controllers.Requests.Locations;

public class GetLocationAvailableCarsRequest
{
    public Guid LocationId { get; set; }
    
    public DateTime RentalStartDate { get; set; }
    
    public DateTime RentalEndDate { get; set; }
}