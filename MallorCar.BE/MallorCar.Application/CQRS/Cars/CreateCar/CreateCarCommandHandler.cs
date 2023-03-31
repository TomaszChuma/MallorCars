using MallorCar.Domain.Entities;
using MallorCarApplication.Common.Interfaces;
using MediatR;

namespace MallorCarApplication.CQRS.Cars.CreateCar;

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Guid>
{
    private readonly IRepository<Car> _carRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCarCommandHandler(IRepository<Car> carRepository, IUnitOfWork unitOfWork)
    {
        _carRepository = carRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Guid> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        var car = new Car
        {
            CarId = Guid.NewGuid(),
            CarRegNumber = request.CarRegNumber,
            ModelId = request.ModelId
        };

        await _carRepository.AddAsync(car, cancellationToken);

        await _unitOfWork.SaveChangesWithNotificationsAsync(new CarCreatedNotification
        {
           CarId = car.CarId,
           LocationId = request.LocationId
        }, cancellationToken);

        return car.CarId;
    }
}