using MediatR;

namespace MallorCarApplication.CQRS.Rentals.CreateRental;

public class CreateRentalCommand : IRequest<Guid>
{
    public Guid ModelId { get; set; }
    
    public Guid RentalStartLocationId { get; set; }
    
    public Guid RentalEndLocationId { get; set; }
    
    public DateTime RentalStartDate { get; set; }
    
    public DateTime RentalEndDate { get; set; }

    public Guid ClientId { get; set; }
}