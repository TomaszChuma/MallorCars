using MallorCar.Controllers.Requests.Locations;
using MallorCarApplication.CQRS.Locations.GetLocationAvailableCars;
using MallorCarApplication.CQRS.Locations.GetLocations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MallorCar.Controllers;

[Route("api/locations")]
[ApiController]
public class LocationController : ControllerBase
{
    private readonly IMediator _mediator;

    public LocationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetLocationsResponse>>> GetLocations(CancellationToken cancellationToken)
    {
        return StatusCode(
            StatusCodes.Status200OK, await _mediator.Send(new GetLocationsQuery(), cancellationToken));
    }

    [HttpGet("locationId/rentals/dateRange/availableCars")] // TODO think about api path
    public async Task<ActionResult<IEnumerable<GetLocationAvailableCarsResponse>>> GetLocationAvailableCars(
        [FromQuery] GetLocationAvailableCarsRequest request,
        CancellationToken cancellationToken)
    {
        return StatusCode(
            StatusCodes.Status200OK, await _mediator.Send(new GetLocationAvailableCarsQuery
            {
                LocationId = request.LocationId,
                RentalStartDate = request.RentalStartDate,
                RentalEndDate = request.RentalEndDate
            }, cancellationToken));
    }
}