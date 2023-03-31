using MediatR;

namespace MallorCarApplication.CQRS.Model.UpdateModelDailyBasePrice;

public class UpdateModelDailyBasePriceCommand : IRequest
{
    public Guid ModelId { get; set; }
    
    public decimal ModelDailyBasePrice { get; set; }
}