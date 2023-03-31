using MediatR;

namespace MallorCarApplication.CQRS.Model.GetModels;

public class GetModelsQuery : IRequest<IEnumerable<GetModelsResponse>>
{
    
}