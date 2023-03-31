using System.Text;
using MallorCar.Domain.Entities;
using MallorCarApplication.Common.Interfaces;
using MediatR;

namespace MallorCarApplication.CQRS.Rentals.CreateRental;

public class CreateRentalCommandHandler : IRequestHandler<CreateRentalCommand, Guid>
{
    private readonly IRentalRepository _rentalRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRentalCommandHandler(
        IRentalRepository rentalRepository,
        IUnitOfWork unitOfWork)
    {
        _rentalRepository = rentalRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
    {
        var carForRentId = await _rentalRepository.GetSpecificCarForRent(request.RentalStartLocationId, request.ModelId, request.RentalStartDate,
            request.RentalEndDate);

        var rental = new Rental
        {
            RentalId = Guid.NewGuid(),
            RentalStartDate = request.RentalStartDate.AddSeconds(-request.RentalStartDate.Second),
            RentalEndDate = request.RentalEndDate.AddSeconds(-request.RentalEndDate.Second),
            RentalStartLocationId = request.RentalStartLocationId,
            RentalEndLocationId = request.RentalEndLocationId,
            ClientId = request.ClientId,
            CarId = carForRentId,
            RentalCode = CreatePassword(8)
        };

        await _rentalRepository.AddAsync(rental, cancellationToken);
        
        await _unitOfWork.SaveChangesWithNotificationsAsync(new RentalCreatedNotification
        {
            RentalId = rental.RentalId
        }, cancellationToken);

        return rental.RentalId;
    }
    
    private string CreatePassword(int length)
    {
        const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        StringBuilder res = new StringBuilder();
        Random rnd = new Random();
        while (0 < length--)
        {
            res.Append(valid[rnd.Next(valid.Length)]);
        }
        return res.ToString();
    }
}