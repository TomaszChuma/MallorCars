using MallorCar.Controllers.Requests.Model;
using MallorCarApplication.CQRS.Model.GetModels;
using MallorCarApplication.CQRS.Model.UpdateModelDailyBasePrice;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MallorCar.Controllers;

[Route("api/models")]
[ApiController]
public class ModelController : ControllerBase
{
    private readonly IMediator _mediator;

    public ModelController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetModelsResponse>>> GetModels(
        CancellationToken cancellationToken)
    {
        return StatusCode(
            StatusCodes.Status200OK, await _mediator.Send(new GetModelsQuery(), cancellationToken));
    }
    
    [HttpPatch]
    public async Task<ActionResult> UpdateModelDailyBasePrice(
        [FromBody] UpdateModelDailyBasePriceRequest request,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(new UpdateModelDailyBasePriceCommand
            {
                ModelId = request.ModelId,
                ModelDailyBasePrice = request.ModelDailyBasePrice
            }, cancellationToken);
        
        return StatusCode(StatusCodes.Status204NoContent);
    }
}