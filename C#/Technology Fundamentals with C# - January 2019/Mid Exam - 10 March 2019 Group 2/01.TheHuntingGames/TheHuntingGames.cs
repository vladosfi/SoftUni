using System;
using System.Threading;

namespace _01.TheHuntingGames
{
    class TheHuntingGames
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            int daysOfTheAdventure = int.Parse(Console.ReadLine());
            int playersCount = int.Parse(Console.ReadLine());
            decimal energyLevel = decimal.Parse(Console.ReadLine());
            decimal waterPerDayForOnePerson = decimal.Parse(Console.ReadLine());
            decimal foodPerDayForOnePerson = decimal.Parse(Console.ReadLine());
            decimal waterSupply = waterPerDayForOnePerson * daysOfTheAdventure * playersCount;
            decimal foodSupply = foodPerDayForOnePerson * daysOfTheAdventure * playersCount;

            if (playersCount != 0)
            {
                for (int i = 1; i <= daysOfTheAdventure; i++)
                {
                    energyLevel -= decimal.Parse(Console.ReadLine());

                    if (energyLevel <= 0)
                    {
                        break;
                    }

                    if (i % 2 == 0)
                    {
                        energyLevel += energyLevel * 0.05m;
                        waterSupply -= waterSupply * 0.3m;
                    }

                    if (i % 3 == 0)
                    {
                        foodSupply -= foodSupply / playersCount;
                        energyLevel += energyLevel * 0.1m;
                    }

                }
            }            


            if (energyLevel > 0)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {energyLevel:f02} energy!");
            }
            else
            {
                Console.WriteLine($"You will run out of energy. You will be left with {foodSupply:f02} food and {waterSupply:f02} water.");
            }
        }
    }
}
