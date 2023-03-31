using MallorCar.Controllers.Requests.Car;
using MallorCarApplication.CQRS.Cars.CreateCar;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MallorCar.Controllers;

[Route("api/cars")]
public class CarController : ControllerBase
{
    private readonly IMediator _mediator;

    public CarController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateCar(
        [FromBody] CreateCarRequest request,
        CancellationToken cancellationToken)
    {
        return StatusCode(
            StatusCodes.Status201Created, await _mediator.Send(new CreateCarCommand
            {
                ModelId = request.ModelId,
                CarRegNumber = request.CarRegNumber,
                LocationId = request.LocationId
            }, cancellationToken));
    }
    
}