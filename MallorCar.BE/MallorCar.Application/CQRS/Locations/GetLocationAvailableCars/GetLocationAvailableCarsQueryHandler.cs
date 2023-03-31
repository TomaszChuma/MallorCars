using MallorCar.Domain.Entities;
using MallorCarApplication.Common.Interfaces;
using MediatR;

namespace MallorCarApplication.CQRS.Locations.GetLocationAvailableCars;

public class GetLocationAvailableCarsQueryHandler : IRequestHandler<GetLocationAvailableCarsQuery, IEnumerable<GetLocationAvailableCarsResponse>>
{
    private readonly IRentalRepository _rentalRepository;

    public GetLocationAvailableCarsQueryHandler(IRentalRepository rentalRepository)
    {
        _rentalRepository = rentalRepository;
    }

    public async Task<IEnumerable<GetLocationAvailableCarsResponse>> Handle(GetLocationAvailableCarsQuery request, CancellationToken cancellationToken)
    {
        var locationAvailableCars = await
            _rentalRepository.GetAvailableCars(request.LocationId, request.RentalStartDate, request.RentalEndDate);

        return locationAvailableCars;
    }
}