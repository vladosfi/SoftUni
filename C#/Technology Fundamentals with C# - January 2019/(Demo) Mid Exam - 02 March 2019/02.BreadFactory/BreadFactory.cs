using System;

namespace _02.BreadFactory
{
    class BreadFactory
    {
        static void Main()
        {
            int energy = 100;
            int coins = 100;

            string[] dayEvents = Console.ReadLine().Split("|");

            for (int i = 0; i < dayEvents.Length; i++)
            {
                string[] tokens = dayEvents[i].Split("-");
                string evnt = tokens[0];
                int number = int.Parse(tokens[1]);

                if (evnt == "rest")
                {
                    int gainedEnergy = 0;

                    if (energy + number <= 100)
                    {
                        gainedEnergy = number;
                        energy += number;
                    }
                    else
                    {
                        energy = 100;
                    }

                    Console.WriteLine($"You gained {gainedEnergy} energy.");
                    Console.WriteLine($"Current energy: {energy}.");
                }
                else if (evnt == "order")
                {
                    if (energy - 30 >= 0)
                    {
                        coins += number;
                        energy -= 30;
                        Console.WriteLine($"You earned {number} coins.");
                    }
                    else
                    {
                        energy = (energy + 50 <= 100) ? (energy + 50) : 100;
                        Console.WriteLine("You had to rest!");
                    }
                }
                else
                {
                    if (!(coins - number <= 0))
                    {
                        coins -= number;
                        Console.WriteLine($"You bought {evnt}.");
                    }
                    else
                    {
                        Console.WriteLine($"Closed! Cannot afford {evnt}.");
                        return;
                    }
                }
            }

            Console.WriteLine("Day completed!");
            Console.WriteLine($"Coins: {coins}");
            Console.WriteLine($"Energy: {energy}");
        }
    }
}
