using MediatR;

namespace MallorCarApplication.CQRS.Cars.CreateCar;

public class CreateCarCommand : IRequest<Guid>
{
    public Guid ModelId { get; set; }

    public string CarRegNumber { get; set; } = default!;
    
    public Guid LocationId { get; set; }
}