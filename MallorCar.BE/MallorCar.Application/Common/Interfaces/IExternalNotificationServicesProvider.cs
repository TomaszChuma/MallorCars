namespace MallorCarApplication.Common.Interfaces;

public interface IExternalNotificationServicesProvider
{
    void SendMessage(string clientName, string carModel, string rentalCode, DateTime startDate, DateTime endDate,
        string startLocation,
        string endLocation,
        decimal totalCost,
        string receiverEmail,
        string receiverPhoneNumber);
}