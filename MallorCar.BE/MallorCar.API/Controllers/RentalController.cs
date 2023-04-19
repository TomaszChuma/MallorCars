using MallorCar.Controllers.Requests.Rental;
using MallorCarApplication.CQRS.Rentals.CreateRental;
using MallorCarApplication.CQRS.Rentals.GetRentalDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MallorCar.Controllers;

[Route("api/rentals")]
[ApiController]
public class RentalController : ControllerBase
{
    private readonly IMediator _mediator;

    public RentalController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("/rentalCode/rental")]
    public async Task<ActionResult<GetRentalDetailsResponse>> GetRentalDetails(
        [FromQuery] GetRentalDetailsRequest request,
        CancellationToken cancellationToken)
    {
        var query = await _mediator.Send(new GetRentalDetailsQuery
        {
            RentalCode = request.RentalCode
        }, cancellationToken);
        
        return StatusCode(
            StatusCodes.Status200OK, query);
    }
    

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateRental(
        [FromBody] CreateRentalRequest request,
        CancellationToken cancellationToken)
    {
        var command = await _mediator.Send(new CreateRentalCommand
        {
            ModelId = request.ModelId,
            RentalStartLocationId = request.RentalStartLocationId,
            RentalEndLocationId = request.RentalEndLocationId,
            RentalStartDate = request.RentalStartDate,
            RentalEndDate = request.RentalEndDate,
            ClientId = request.ClientId
        }, cancellationToken);
        
        
        return StatusCode(
            StatusCodes.Status201Created, command);
    }
}