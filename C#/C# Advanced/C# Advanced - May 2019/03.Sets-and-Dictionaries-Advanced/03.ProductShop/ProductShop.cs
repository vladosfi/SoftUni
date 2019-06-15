using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _03.ProductShop
{
    class ProductShop
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            string input = Console.ReadLine();
            var shops = new Dictionary<string, Dictionary<string, double>>();

            while (input != "Revision")
            {
                string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = tokens[0];
                string product = tokens[1];
                double price = double.Parse(tokens[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }

                if (!shops[shop].ContainsKey(product))
                {
                    shops[shop].Add(product, 0);
                }

                shops[shop][product] = price;

                input = Console.ReadLine();
            }

            var sortedShops = shops.OrderBy(x => x.Key);

            foreach (var kvp in sortedShops)
            {
                Console.WriteLine($"{kvp.Key}->");

                foreach (var innerKvp in kvp.Value)
                {
                    Console.WriteLine($"Product: {innerKvp.Key}, Price: {innerKvp.Value}");
                }
            }
        }
    }
}
