using MallorCarApplication.Common.Interfaces;
using MediatR;

namespace MallorCarApplication.CQRS.Model.GetModels;

public class GetModelsQueryHandler : IRequestHandler<GetModelsQuery, IEnumerable<GetModelsResponse>>
{
    private readonly IRepository<MallorCar.Domain.Entities.Model> _modelRepository;

    public GetModelsQueryHandler(IRepository<MallorCar.Domain.Entities.Model> modelRepository)
    {
        _modelRepository = modelRepository;
    }

    public async Task<IEnumerable<GetModelsResponse>> Handle(GetModelsQuery request, CancellationToken cancellationToken)
    {
        var models = await _modelRepository.GetManyAsync(null, cancellationToken);

        var groupedModels = models.OrderBy(x => x.ModelName);

        return groupedModels.Select(model => new GetModelsResponse
        {
            ModelId = model.ModelId,
            ModelName = model.ModelName,
            ModelSubName = model.ModelSubName,
            ModelDailyPrice = model.ModelBaseDailyPrice,
            ModelPhotoUrl = model.ModelPhotoUrl
        });
    }
}