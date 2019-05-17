using System;

namespace _01.TripToWorldCup
{
    class Program
    {
        static void Main(string[] args)
        {
            double ticketForGoing = double.Parse(Console.ReadLine());
            double ticketForBack = double.Parse(Console.ReadLine());
            double ticketForOneMatch = double.Parse(Console.ReadLine());
            int numberOfMatches = int.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());
            double totalSum = (ticketForGoing + ticketForBack) * 6;
            totalSum = totalSum - ((totalSum * discount) / 100);
            totalSum = totalSum + (ticketForOneMatch * numberOfMatches * 6);

            Console.WriteLine($"Total sum: {(totalSum):f02} lv.");
            Console.WriteLine($"Each friend has to pay {totalSum / 6:f02} lv.");

        }
    }
}
