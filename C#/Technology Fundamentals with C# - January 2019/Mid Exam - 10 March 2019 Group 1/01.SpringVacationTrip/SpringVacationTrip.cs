using System;
using System.Threading;

namespace _01.SpringVacationTrip
{
    class SpringVacationTrip
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            int daysOfTrip = int.Parse(Console.ReadLine());
            decimal budget = decimal.Parse(Console.ReadLine());
            int groupOfPeople = int.Parse(Console.ReadLine());
            decimal priceForFuelPerKm = decimal.Parse(Console.ReadLine());
            decimal foodExpencesPerPersonForDay = decimal.Parse(Console.ReadLine());
            decimal roomPriceForNightPerPerson = decimal.Parse(Console.ReadLine());
            decimal totalExpences = 0;

            if (groupOfPeople > 10)
            {
                roomPriceForNightPerPerson = roomPriceForNightPerPerson - (roomPriceForNightPerPerson * 0.25m);
            }

            decimal foodExpences = foodExpencesPerPersonForDay * groupOfPeople * daysOfTrip;
            decimal roomPrice = roomPriceForNightPerPerson * groupOfPeople * daysOfTrip;
            totalExpences = foodExpences + roomPrice;

            for (int i = 1; i <= daysOfTrip; i++)
            {
                decimal fuelForCurrentDay = decimal.Parse(Console.ReadLine()) * priceForFuelPerKm;
                totalExpences += fuelForCurrentDay;

                if (i % 3 == 0 || i % 5 == 0)
                {
                    totalExpences += totalExpences * 0.4m;
                }

                if (i % 7 == 0)
                {
                    totalExpences -= (totalExpences / groupOfPeople);
                }

                if (totalExpences > budget)
                {
                    Console.WriteLine($"Not enough money to continue the trip. You need {(totalExpences - budget):f02}$ more.");
                    return;
                }
            }

            Console.WriteLine($"You have reached the destination. You have {(budget - totalExpences):f02}$ budget left.");


        }
    }
}
