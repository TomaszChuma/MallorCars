using MallorCarApplication.Common.Interfaces;
using MediatR;

namespace MallorCarApplication.CQRS.Model.UpdateModelDailyBasePrice;

public class UpdateModelDailyBasePriceCommandHandler : IRequestHandler<UpdateModelDailyBasePriceCommand>
{
    private readonly IRepository<MallorCar.Domain.Entities.Model> _modelRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateModelDailyBasePriceCommandHandler(
        IRepository<MallorCar.Domain.Entities.Model> modelRepository, 
        IUnitOfWork unitOfWork)
    {
        _modelRepository = modelRepository;
        _unitOfWork = unitOfWork;
    }
    
    
    public async Task Handle(UpdateModelDailyBasePriceCommand request, CancellationToken cancellationToken)
    {
        var model = await _modelRepository.FindAsync(x => x.ModelId == request.ModelId, cancellationToken);

        if (model != null) model.ModelBaseDailyPrice = request.ModelDailyBasePrice;

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}