using MallorCar.Domain.Entities;
using MallorCarApplication.Common.Interfaces;
using MallorCarApplication.CQRS.Cars.CreateCar;
using MediatR;

namespace MallorCarApplication.CQRS.Rentals;

public class MoveCarToStartLocationWhenCarCreatedNotificationHandler : INotificationHandler<CarCreatedNotification>
{
    private readonly IRepository<Rental> _rentalRepository;
    private readonly IUnitOfWork _unitOfWork;

    public MoveCarToStartLocationWhenCarCreatedNotificationHandler(
        IRepository<Rental> rentalRepository,
        IUnitOfWork unitOfWork)
    {
        _rentalRepository = rentalRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task Handle(CarCreatedNotification notification, CancellationToken cancellationToken)
    {
        var rental = new Rental
        {
            RentalId = Guid.NewGuid(),
            RentalCode = "NEWCAR",
            RentalStartLocationId = Guid.Parse("e2858625-1c59-4144-9337-aa5855675027"),
            RentalEndLocationId = notification.LocationId,
            RentalStartDate = DateTime.UtcNow,
            RentalEndDate = DateTime.UtcNow,
            CarId = notification.CarId,
            ClientId = Guid.Parse("d7313719-e5c1-4bd4-b163-f79f13cccfa4")
        };

        await _rentalRepository.AddAsync(rental, cancellationToken);

        await _unitOfWork.SaveChangesAsync();
    }
}