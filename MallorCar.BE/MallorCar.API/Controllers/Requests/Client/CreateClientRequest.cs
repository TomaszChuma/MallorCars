namespace MallorCar.Controllers.Requests.Client;

public class CreateClientRequest
{
    public string ClientFirstName { get; set; } = default!;

    public string ClientLastName { get; set; } = default!;

    public string ClientEmail { get; set; } = default!;

    public string ClientPhoneNumber { get; set; } = default!;
}