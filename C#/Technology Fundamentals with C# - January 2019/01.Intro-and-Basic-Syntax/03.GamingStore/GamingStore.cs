using System;
using System.Threading;

namespace _03.GamingStore
{
    class GamingStore
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            decimal currentBalance = decimal.Parse(Console.ReadLine());
            decimal spendMoneyForGames = 0;

            while (true)
            {
                string input = Console.ReadLine();
                decimal moneyForGame = 0;

                if (input == "Game Time")
                {
                    Console.WriteLine($"Total spent: ${spendMoneyForGames}. Remaining: ${currentBalance}");
                    break;
                }

                if (input == "OutFall 4" || input == "RoverWatch Origins Edition")
                {
                    moneyForGame = 39.99m;
                }
                else if (input == "CS: OG")
                {
                    moneyForGame = 15.99m;
                }
                else if (input == "Zplinter Zell")
                {
                    moneyForGame = 19.99m;
                }
                else if (input == "Honored 2")
                {
                    moneyForGame = 59.99m;
                }
                else if (input == "RoverWatch")
                {
                    moneyForGame = 29.99m;
                }
                else
                {
                    Console.WriteLine("Not Found");
                    continue;
                }

                if (currentBalance < moneyForGame)
                {
                    Console.WriteLine("Too Expensive");
                }
                else
                {
                    spendMoneyForGames += moneyForGame;
                    currentBalance -= moneyForGame;
                    Console.WriteLine($"Bought {input}");
                }

                if (currentBalance <= 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }
            }
        }
    }
}
