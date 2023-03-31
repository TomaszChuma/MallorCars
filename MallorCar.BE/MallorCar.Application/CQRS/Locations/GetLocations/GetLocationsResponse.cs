namespace MallorCarApplication.CQRS.Locations.GetLocations;

public class GetLocationsResponse
{
    public Guid LocationId { get; set; }

    public string LocationName { get; set; } = default!;
}