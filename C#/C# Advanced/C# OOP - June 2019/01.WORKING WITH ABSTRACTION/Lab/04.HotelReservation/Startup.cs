using System;
using System.Threading;

namespace HotelReservation
{
    public class Startup
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            string[] reservationInfo = Console.ReadLine().Split();
            decimal pricePerDay = decimal.Parse(reservationInfo[0]);
            int numberOfDays = int.Parse(reservationInfo[1]);
            Enum.TryParse(reservationInfo[2], out Season season);
            DiscountType discountType = DiscountType.None;

            //var seasonTest = Enum.Parse<Season>(reservationInfo[2], ignoreCase: true);
            
            if (reservationInfo.Length == 4)
            {
                Enum.TryParse(reservationInfo[3], out discountType);
            }

            var reservationPrice = PriceCalculator.GetTotalPrice(pricePerDay, numberOfDays, season, discountType);

            Console.WriteLine($"{reservationPrice:f2}");
        }
    }
}
