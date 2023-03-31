namespace MallorCarApplication.Common.Helpers;

public static class CostCalculations
{
    public static decimal CalculateTotalCost(DateTime rentalStartDate, DateTime rentalEndDate, decimal dailyPrice)
    {
        var numOfRentalDays = (int)Math.Ceiling((rentalEndDate - rentalStartDate).TotalDays);
        
        decimal totalPrice = 0;
        decimal discountForDay = 1;

        for (int i = 0; i < numOfRentalDays; i++)
        {
            totalPrice += dailyPrice * discountForDay;
            if (discountForDay >= (decimal)0.5)
            {
                discountForDay -= (decimal)0.1;
            }
        }

        return totalPrice;
    }
}