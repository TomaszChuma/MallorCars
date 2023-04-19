using MallorCar.Controllers.Requests.Client;
using MallorCarApplication.CQRS.Clients.CreateClient;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MallorCar.Controllers;

[Route("api/clients")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateClient(
        [FromBody] CreateClientRequest request, CancellationToken cancellationToken)
    {
        var command = await _mediator.Send(new CreateClientCommand
        {
            ClientFirstName = request.ClientFirstName,
            ClientLastName = request.ClientLastName,
            ClientEmail = request.ClientEmail,
            ClientPhoneNumber = request.ClientPhoneNumber
        }, cancellationToken);
        
        return StatusCode(
            StatusCodes.Status201Created, command);
    }
}