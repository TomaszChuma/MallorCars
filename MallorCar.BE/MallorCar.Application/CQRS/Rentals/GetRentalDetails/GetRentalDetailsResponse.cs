namespace MallorCarApplication.CQRS.Rentals.GetRentalDetails;

public class GetRentalDetailsResponse
{
    public string? RentalStartLocationName { get; set; }
    
    public string RentalEndLocationName { get; set; } = default!;

    public DateTime RentalStartDate { get; set; }
    
    public DateTime RentalEndDate { get; set; }

    public string RentalCarModelName { get; set; } = default!;
    
    public string? RentalCarModelSubName { get; set; }

    public string RentalCarPhotoUrl { get; set; } = default!;
}