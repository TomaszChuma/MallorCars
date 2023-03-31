namespace MallorCar.Domain.Entities;

public class Model
{
    public Guid ModelId { get; set; }

    public string ModelName { get; set; } = default!;
    
    public string? ModelSubName { get; set; }

    public decimal ModelBaseDailyPrice { get; set; }

    public int ModelRange { get; set; }

    public int ModelNumOfSeats { get; set; }

    public double ModelAcceleration { get; set; }

    public double ModelTopSpeed { get; set; }

    public string ModelPhotoUrl { get; set; } = default!;

    public virtual ICollection<Car> Cars { get; set; } = default!;
}