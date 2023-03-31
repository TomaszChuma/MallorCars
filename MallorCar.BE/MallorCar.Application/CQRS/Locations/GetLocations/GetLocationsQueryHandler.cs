using MallorCar.Domain.Entities;
using MallorCarApplication.Common.Interfaces;
using MediatR;

namespace MallorCarApplication.CQRS.Locations.GetLocations;

public class GetLocationsQueryHandler : IRequestHandler<GetLocationsQuery, IEnumerable<GetLocationsResponse>>
{
    private readonly IRepository<Location> _locationRepository;

    public GetLocationsQueryHandler(IRepository<Location> locationRepository)
    {
        _locationRepository = locationRepository;
    }
    
    public async Task<IEnumerable<GetLocationsResponse>> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
    {
        var locations = await _locationRepository.GetManyAsync(null, cancellationToken);

        return locations.Select(location => new GetLocationsResponse
        {
            LocationId = location.LocationId,
            LocationName = location.LocationName
        });
    }
}