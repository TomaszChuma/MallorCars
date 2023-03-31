namespace MallorCarApplication.CQRS.Locations.GetLocationAvailableCars;

public class GetLocationAvailableCarsResponse
{
    public Guid ModelId { get; set; }
    public string ModelName { get; set; } = default!;

    public string ModelSubName { get; set; } = default!;
    
    public decimal TotalCost { get; set; }
    
    public int NumOfAvailableCars { get; set; }
    
    public int ModelRange { get; set; }
    
    public int ModelNumOfSeats { get; set; }
    
    public double ModelAcceleration { get; set; }
    
    public double ModelTopSpeed { get; set; }

    public string ModelPhotoUrl { get; set; } = default!;
}