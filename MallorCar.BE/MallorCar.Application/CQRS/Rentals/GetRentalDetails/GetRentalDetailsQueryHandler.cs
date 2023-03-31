using MallorCar.Domain.Entities;
using MallorCarApplication.Common.Interfaces;
using MediatR;

namespace MallorCarApplication.CQRS.Rentals.GetRentalDetails;

public class GetRentalDetailsQueryHandler : IRequestHandler<GetRentalDetailsQuery, GetRentalDetailsResponse>
{
    private readonly IRentalRepository _rentalRepository;

    public GetRentalDetailsQueryHandler(IRentalRepository rentalRepository)
    {
        _rentalRepository = rentalRepository;
    }
    
    public async Task<GetRentalDetailsResponse> Handle(GetRentalDetailsQuery request, CancellationToken cancellationToken)
    {
        var rental = await _rentalRepository.GetRentalDetailsByRentalCode(request.RentalCode);

        return new GetRentalDetailsResponse
        {
            RentalStartLocationName = rental.RentalStartLocation.LocationName,
            RentalEndLocationName = rental.RentalEndLocation.LocationName,
            RentalStartDate = rental.RentalStartDate,
            RentalEndDate = rental.RentalEndDate,
            RentalCarModelName = rental.Car.Model.ModelName,
            RentalCarModelSubName = rental.Car.Model.ModelSubName,
            RentalCarPhotoUrl = rental.Car.Model.ModelPhotoUrl
        };
    }
}