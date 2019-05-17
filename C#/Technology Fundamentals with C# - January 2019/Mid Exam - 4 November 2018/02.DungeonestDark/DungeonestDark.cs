using System;

namespace _02.DungeonestDark
{
    class DungeonestDark
    {
        static void Main()
        {
            int health = 100;
            int coins = 0;
            string[] input = Console.ReadLine().Split("|");
            int[] bestRoom = new int[2];
            bestRoom[0] = 1;

            for (int i = 0; i < input.Length; i++)
            {
                string[] tokens = input[i].Split();
                string itemOrMonster = tokens[0];
                int number = int.Parse(tokens[1]);
                
                if (itemOrMonster == "potion")
                {
                    int healed = 0;

                    if (health + number <= 100)
                    {
                        healed = number;
                        health = health + number;
                    }
                    else
                    {
                        healed = 100 - health;
                        health = 100;
                    }

                    Console.WriteLine($"You healed for {healed} hp.");
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (itemOrMonster == "chest")
                {
                    coins += number;
                    Console.WriteLine($"You found {number} coins.");
                }
                else
                {
                    if (bestRoom[1] <= number)
                    {
                        bestRoom[1] = number;
                        bestRoom[0] = i+1;
                    }

                    if (!(health - number <= 0))
                    {
                        health -= number;
                        Console.WriteLine($"You slayed {itemOrMonster}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {itemOrMonster}.");
                        Console.WriteLine($"Best room: {bestRoom[0]}");
                        return;
                    }
                }
            }

            Console.WriteLine("You've made it!");
            Console.WriteLine($"Coins: {coins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
