using System;

namespace _06.FishingBoat
{
    class FishingBoat
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            byte fishermans = byte.Parse(Console.ReadLine());
            double expenses = 0;

            switch (season)
            {
                case "Spring":
                    expenses = 3000;
                    break;
                case "Summer":
                case "Autumn":
                    expenses = 4200;
                    break;
                case "Winter":
                    expenses = 2600;
                    break;
                default:
                    break;
            }

            if (fishermans <= 6)
            {
                expenses = expenses - (expenses * 0.1);
            }
            else if (fishermans >= 7 && fishermans <=11)
            {
                expenses = expenses - (expenses * 0.15);
            }
            else if (fishermans > 12)
            {
                expenses = expenses - (expenses * 0.25);
            }


            if (fishermans % 2 == 0 && season != "Autumn")
            {
                expenses = expenses - (expenses * 0.05);
            }

            if (budget >= expenses)
            {
                Console.WriteLine($"Yes! You have {(budget - expenses):f02} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {(expenses - budget):f02} leva.");
            }

        }
    }
}
