using System;
using System.Collections.Generic;
using System.Threading;

namespace _02.HelloFrance
{
    class HelloFrance
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            string[] items = Console.ReadLine().Split("|");
            decimal budget = decimal.Parse(Console.ReadLine());

            decimal expences = budget;
            List<decimal> buyedItems = new List<decimal>();

            for (int i = 0; i < items.Length; i++)
            {
                string[] tokens = items[i].Split("->");
                string item = tokens[0];
                decimal itemPrice = decimal.Parse(tokens[1]);

                if ((item == "Clothes" && itemPrice <= 50.00m)
                    || (item == "Shoes" && itemPrice <= 35.00m)
                    || (item == "Accessories" && itemPrice <= 20.50m))
                {                    
                    if (expences - itemPrice >= 0)
                    {
                        expences -= itemPrice;
                        itemPrice += itemPrice * 0.4m;
                        buyedItems.Add(itemPrice);
                    }
                }
            }

            decimal proofit = 0;

            foreach (var item in buyedItems)    
            {
                Console.Write($"{item:f02} ");
                proofit += item;
            }

            proofit = proofit - (budget - expences);

            Console.WriteLine();
            Console.WriteLine($"Profit: {proofit:f02}");

            if (proofit + budget >= 150)
            {
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine("Time to go.");
            }
        }
    }
}
