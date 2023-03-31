namespace MallorCar.Controllers.Requests.Model;

public class UpdateModelDailyBasePriceRequest
{
    public Guid ModelId { get; set; }
    
    public decimal ModelDailyBasePrice { get; set; }
}