using MallorCar.Domain.Entities;
using MallorCarApplication.Common.Interfaces;
using MediatR;

namespace MallorCarApplication.CQRS.Clients.CreateClient;

public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Guid>
{
    private readonly IRepository<Client> _clientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateClientCommandHandler(IRepository<Client> clientRepository, IUnitOfWork unitOfWork)
    {
        _clientRepository = clientRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Guid> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var client = await _clientRepository.FindAsync(x =>
            x.ClientEmail == request.ClientEmail);

        if (client is not null)
        {
            client.ClientFirstName = request.ClientFirstName;
            client.ClientLastName = request.ClientLastName;
            client.ClientPhoneNumber = request.ClientPhoneNumber;

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return client.ClientId;
        }
        
        client = new Client
        {
            ClientId = Guid.NewGuid(),
            ClientFirstName = request.ClientFirstName,
            ClientLastName = request.ClientLastName,
            ClientEmail = request.ClientEmail,
            ClientPhoneNumber = request.ClientPhoneNumber
        };

        await _clientRepository.AddAsync(client, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return client.ClientId;
    }
}