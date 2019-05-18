using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _03.ProductShop
{
    class ProductShop
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            var shops = new Dictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input=="Revision")
                {
                    break;
                }
                string name = input.Split(", ")[0];
                string product = input.Split(", ")[1];
                double price = double.Parse(input.Split(", ")[2]);

                if (!shops.ContainsKey(name))
                {
                    shops[name] = new Dictionary<string, double>();
                }

                if (!shops[name].ContainsKey(product))
                {
                    shops[name][product] = 0;
                }

                shops[name][product] = price;
            }

            foreach (var shopKvp in shops.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{shopKvp.Key} -> ");

                foreach (var productKvp in shopKvp.Value)
                {
                    Console.WriteLine($"Product: {productKvp.Key}, Price: {productKvp.Value}");
                }
            }
        }
    }
}
