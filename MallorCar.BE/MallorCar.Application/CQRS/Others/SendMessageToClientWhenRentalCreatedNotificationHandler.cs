using MallorCarApplication.Common.Helpers;
using MallorCarApplication.Common.Interfaces;
using MallorCarApplication.CQRS.Rentals.CreateRental;
using MediatR;

namespace MallorCarApplication.CQRS.Others;

public class SendMessageToClientWhenRentalCreatedNotificationHandler : INotificationHandler<RentalCreatedNotification>
{
    private readonly IExternalNotificationServicesProvider _externalNotificationServicesProvider;
    private readonly IRentalRepository _rentalRepository;

    public SendMessageToClientWhenRentalCreatedNotificationHandler(
        IExternalNotificationServicesProvider externalNotificationServicesProvider,
        IRentalRepository rentalRepository)
    {
        _externalNotificationServicesProvider = externalNotificationServicesProvider;
        _rentalRepository = rentalRepository;
    }

    public async Task Handle(RentalCreatedNotification notification, CancellationToken cancellationToken)
    {
        var rental = await _rentalRepository.GetRentalDetails(notification.RentalId);

        var totalCost = CostCalculations.CalculateTotalCost(
            rental.RentalStartDate, 
            rental.RentalEndDate,
            rental.Car.Model.ModelBaseDailyPrice);


        _externalNotificationServicesProvider.SendMessage(
            rental.Client.ClientFirstName,
            rental.Car.Model.ModelName,
            rental.RentalCode,
            rental.RentalStartDate,
            rental.RentalEndDate,
            rental.RentalStartLocation.LocationName,
            rental.RentalEndLocation.LocationName,
            totalCost,
            rental.Client.ClientEmail,
            rental.Client.ClientPhoneNumber
        );
    }
}