using MediatR;

namespace MallorCarApplication.CQRS.Locations.GetLocations;

public class GetLocationsQuery : IRequest<IEnumerable<GetLocationsResponse>>
{
}