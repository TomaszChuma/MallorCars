using MediatR;

namespace MallorCarApplication.CQRS.Cars.CreateCar;

public class CarCreatedNotification : INotification
{
    public Guid CarId { get; set; }
    
    public Guid LocationId { get; set; }
}