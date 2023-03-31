using MediatR;

namespace MallorCarApplication.CQRS.Rentals.CreateRental;

public class RentalCreatedNotification : INotification
{
    public Guid RentalId { get; set; }
}