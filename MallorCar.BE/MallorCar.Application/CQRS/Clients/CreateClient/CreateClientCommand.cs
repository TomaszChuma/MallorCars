using MediatR;

namespace MallorCarApplication.CQRS.Clients.CreateClient;

public class CreateClientCommand : IRequest<Guid>
{
    public string ClientFirstName { get; set; } = default!;

    public string ClientLastName { get; set; } = default!;

    public string ClientEmail { get; set; } = default!;

    public string ClientPhoneNumber { get; set; } = default!;
}