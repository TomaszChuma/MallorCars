using MediatR;

namespace MallorCarApplication.CQRS.Locations.GetLocationAvailableCars;

public class GetLocationAvailableCarsQuery : IRequest<IEnumerable<GetLocationAvailableCarsResponse>>
{
    public Guid LocationId { get; set; }
    
    public DateTime RentalStartDate { get; set; }
    
    public DateTime RentalEndDate { get; set; }
}