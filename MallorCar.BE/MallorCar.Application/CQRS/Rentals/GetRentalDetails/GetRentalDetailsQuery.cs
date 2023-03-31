using MediatR;

namespace MallorCarApplication.CQRS.Rentals.GetRentalDetails;

public class GetRentalDetailsQuery : IRequest<GetRentalDetailsResponse>
{
    public string RentalCode { get; set; } = default!;
}