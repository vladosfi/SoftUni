using System;

namespace _02.QuarterShop
{
    class QuarterShop
    {
        static void Main(string[] args)
        {
            string productName = Console.ReadLine();
            string town = Console.ReadLine();
            decimal quantity = decimal.Parse(Console.ReadLine());

            if (town == "Sofia")
            {
                if (productName == "coffee")
                {
                    Console.WriteLine(quantity * 0.50m);
                }
                else if (productName == "water")
                {
                    Console.WriteLine(quantity * 0.80m);
                }
                else if (productName == "beer")
                {
                    Console.WriteLine(quantity * 1.20m);
                }
                else if (productName == "sweets")
                {
                    Console.WriteLine(quantity * 1.45m);
                }
                else if (productName == "peanuts")
                {
                    Console.WriteLine(quantity * 1.60m);
                }
            }
            else if (town == "Plovdiv")
            {
                if (productName == "coffee")
                {
                    Console.WriteLine(quantity * 0.40m);
                }
                else if (productName == "water")
                {
                    Console.WriteLine(quantity * 0.70m);
                }
                else if (productName == "beer")
                {
                    Console.WriteLine(quantity * 1.15m);
                }
                else if (productName == "sweets")
                {
                    Console.WriteLine(quantity * 1.30m);
                }
                else if (productName == "peanuts")
                {
                    Console.WriteLine(quantity * 1.50m);
                }
            }
            else if (town == "Varna")
            {
                if (productName == "coffee")
                {
                    Console.WriteLine(quantity * 0.45m);
                }
                else if (productName == "water")
                {
                    Console.WriteLine(quantity * 0.70m);
                }
                else if (productName == "beer")
                {
                    Console.WriteLine(quantity * 1.10m);
                }
                else if (productName == "sweets")
                {
                    Console.WriteLine(quantity * 1.35m);
                }
                else if (productName == "peanuts")
                {
                    Console.WriteLine(quantity * 1.55m);
                }
            }
        }
    }
}
