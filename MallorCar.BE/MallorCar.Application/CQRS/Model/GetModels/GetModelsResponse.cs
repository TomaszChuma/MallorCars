namespace MallorCarApplication.CQRS.Model.GetModels;

public class GetModelsResponse
{
    public Guid ModelId { get; set; }

    public string ModelName { get; set; } = default!;

    public string? ModelSubName { get; set; }
    
    public decimal ModelDailyPrice { get; set; }

    public string ModelPhotoUrl { get; set; } = default!;
}