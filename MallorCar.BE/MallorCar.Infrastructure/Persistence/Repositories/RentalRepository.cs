using MallorCar.Domain.Entities;
using MallorCarApplication.Common.Helpers;
using MallorCarApplication.Common.Interfaces;
using MallorCarApplication.CQRS.Locations.GetLocationAvailableCars;
using Microsoft.EntityFrameworkCore;

namespace MallorCar.Infrastructure.Persistence.Repositories;

public class RentalRepository : Repository<Rental>, IRentalRepository
{
    private readonly DbSet<Rental> _table;
    
    public RentalRepository(DbContext dbContext) : base(dbContext)
    {
        _table = dbContext.Set<Rental>();
    }
    
    public async Task<IEnumerable<GetLocationAvailableCarsResponse>> GetAvailableCars(Guid locationId, DateTime rentalStartDate, DateTime rentalEndDate)
    {
        var allRentals = await _table.Include(rental => rental.Car).ThenInclude(car => car.Model).ToListAsync();

        var availableCars = allRentals
            .Where(x => x.RentalEndLocationId == locationId && x.RentalEndDate < rentalStartDate)
            .GroupBy(x => x.CarId, (key, y) => y.OrderBy(d => d.RentalEndDate).Last())
            .Where(x => !allRentals.Where(y => y.CarId == x.CarId).Any(z => z.RentalStartDate > x.RentalEndDate && z.RentalStartDate < rentalEndDate))
            .Where(x => !allRentals.Where(y => y.CarId == x.CarId).Any(z => z.RentalStartDate > rentalStartDate && z.RentalStartDate < rentalEndDate));

        var groupedCars = availableCars.GroupBy(x => new
        {
            x.Car.Model.ModelId,
            x.Car.Model.ModelName,
            x.Car.Model.ModelSubName,
            x.Car.Model.ModelBaseDailyPrice,
            x.Car.Model.ModelRange,
            x.Car.Model.ModelNumOfSeats,
            x.Car.Model.ModelAcceleration,
            x.Car.Model.ModelTopSpeed,
            x.Car.Model.ModelPhotoUrl
        }).Select(x => new {
            x.Key.ModelId,
            x.Key.ModelName, 
            x.Key.ModelSubName,
            x.Key.ModelRange,
            x.Key.ModelNumOfSeats,
            x.Key.ModelAcceleration,
            x.Key.ModelTopSpeed,
            x.Key.ModelPhotoUrl,
            Count = x.Count(), 
            Price = CostCalculations.CalculateTotalCost(rentalStartDate, rentalEndDate, x.Key.ModelBaseDailyPrice)
        });

        return groupedCars.Select(rental => new GetLocationAvailableCarsResponse
        {
            ModelId = rental.ModelId,
            ModelName = rental.ModelName,
            ModelSubName = rental.ModelSubName,
            NumOfAvailableCars = rental.Count,
            TotalCost = rental.Price,
            ModelRange = rental.ModelRange,
            ModelNumOfSeats = rental.ModelNumOfSeats,
            ModelAcceleration = rental.ModelAcceleration,
            ModelTopSpeed = rental.ModelTopSpeed,
            ModelPhotoUrl = rental.ModelPhotoUrl
        });
    }

    public async Task<Guid> GetSpecificCarForRent(Guid locationId, Guid modelId, DateTime rentalStartDate, DateTime rentalEndDate)
    {
        var allRentals = await _table.Include(rental => rental.Car).ThenInclude(car => car.Model).ToListAsync();

        var availableCars = allRentals
            .Where(x => x.RentalEndLocationId == locationId && x.RentalEndDate < rentalStartDate)
            .GroupBy(x => x.CarId, (key, y) => y.OrderBy(d => d.RentalEndDate).Last())
            .Where(x => !allRentals.Where(y => y.CarId == x.CarId).Any(z => z.RentalStartDate > x.RentalEndDate && z.RentalStartDate < rentalEndDate))
            .Where(x => !allRentals.Where(y => y.CarId == x.CarId).Any(z => z.RentalStartDate > rentalStartDate && z.RentalStartDate < rentalEndDate));

        var specificCarForRent = availableCars.First(x => x.Car.ModelId == modelId);

        return specificCarForRent.CarId;
    }

    public async Task<Rental> GetRentalDetails(Guid rentalId)
    {
        var include = _table.Include(rental => rental.Car)
            .ThenInclude(car => car.Model)
            .Include(rental => rental.Client)
            .Include(rental => rental.RentalStartLocation)
            .Include(rental => rental.RentalEndLocation);

        var rental = await include.SingleAsync(x => x.RentalId == rentalId);

        return rental;
    }

    public async Task<Rental?> GetRentalDetailsByRentalCode(string rentalCode)
    {
        var include = _table.Include(rental => rental.Car)
            .ThenInclude(car => car.Model)
            .Include(rental => rental.RentalStartLocation)
            .Include(rental => rental.RentalEndLocation);

        var rental = await include.SingleOrDefaultAsync(x => x.RentalCode == rentalCode);

        return rental;
    }
}