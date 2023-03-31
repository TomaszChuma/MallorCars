using MallorCar.Domain.Entities;
using MallorCarApplication.CQRS.Locations.GetLocationAvailableCars;

namespace MallorCarApplication.Common.Interfaces;

public interface IRentalRepository : IRepository<MallorCar.Domain.Entities.Rental>
{
    Task<IEnumerable<GetLocationAvailableCarsResponse>> GetAvailableCars(Guid locationId, DateTime rentalStartDate, DateTime rentalEndDate);
    
    Task<Guid> GetSpecificCarForRent(Guid locationId, Guid modelId, DateTime rentalStartDate, DateTime rentalEndDate);

    Task<Rental> GetRentalDetails(Guid rentalId);

    Task<Rental> GetRentalDetailsByRentalCode(string rentalCode);
}