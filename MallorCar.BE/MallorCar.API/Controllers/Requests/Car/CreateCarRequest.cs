namespace MallorCar.Controllers.Requests.Car;

public class CreateCarRequest
{
    public Guid ModelId { get; set; }

    public string CarRegNumber { get; set; } = default!;
    
    public Guid LocationId { get; set; }
}