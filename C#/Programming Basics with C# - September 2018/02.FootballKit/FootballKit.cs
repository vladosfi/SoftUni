using System;

namespace _02.FootballKit
{
    class FootballKit
    {
        static void Main(string[] args)
        {
            decimal tshirtPrice = decimal.Parse(Console.ReadLine());
            decimal targetSum = decimal.Parse(Console.ReadLine());
            decimal shorts = tshirtPrice * 0.75m;
            decimal hose = shorts * 0.2m;
            decimal buttons = (tshirtPrice + shorts) * 2;
            decimal totalSum = tshirtPrice + shorts + hose + buttons;
            
            totalSum = totalSum - (totalSum * 0.15m);

            if (totalSum >= targetSum)
            {
                Console.WriteLine("Yes, he will earn the world-cup replica ball!");
                Console.WriteLine($"His sum is {totalSum:f02} lv.");
            }
            else
            {
                Console.WriteLine("No, he will not earn the world-cup replica ball.");
                Console.WriteLine($"He needs {targetSum - totalSum:f02} lv. more.");
            }            
        }
    }
}
