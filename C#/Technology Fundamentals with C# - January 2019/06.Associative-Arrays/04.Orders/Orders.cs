using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace _04.Orders
{
    class Orders
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            Dictionary<string, List<double>> order = new Dictionary<string, List<double>>();

            while (true)
            {
                List<string> orderList = Console.ReadLine()
                .Split(" ")
                .ToList();

                if (orderList[0] == "buy")
                {
                    break;
                }

                List<double> orderPriseAndQuantity = orderList.Skip(1).Select(x => double.Parse(x)).ToList();

                if (!order.ContainsKey(orderList[0]))
                {
                    order.Add(orderList[0], new List<double>());
                    order[orderList[0]] = orderPriseAndQuantity;
                }
                else
                {
                    // Get current values of quantity
                    List<double> oldPriseAndQuantity = order[orderList[0]].ToList();
                    double curQuantity = oldPriseAndQuantity[1] + orderPriseAndQuantity[1];
                    double curPrice = orderPriseAndQuantity[0];

                    // Write values
                    oldPriseAndQuantity[0] = curPrice;
                    oldPriseAndQuantity[1] = curQuantity;
                    order[orderList[0]] = oldPriseAndQuantity;
                }
            }

            foreach (var kvp in order)
            {
                List<double> orderPriceQuontity = kvp.Value.ToList();
                double price = orderPriceQuontity[0] * orderPriceQuontity[1];

                Console.WriteLine($"{kvp.Key} -> {price:f02}");
            }
        }
    }
}