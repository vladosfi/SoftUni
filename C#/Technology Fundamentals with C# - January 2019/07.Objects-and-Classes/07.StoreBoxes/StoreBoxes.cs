using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _07.StoreBoxes
{
    class StoreBoxes
    {
        class Box
        {
            public Box()
            {
                Item = new Item();
            }

            public string SerialNumber { get; set; }

            public Item Item { get; set; }

            public int Quantity { get; set; }

            public decimal PriceForBox { get; set; }
        }

        class Item
        {
            public string Name { get; set; }

            public decimal Price { get; set; }
        }

        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            List<Box> boxes = new List<Box>();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split();

                if (tokens[0] == "end")
                {
                    break;
                }

                string serialNumber = tokens[0];
                string productName = tokens[1];
                int quontity = int.Parse(tokens[2]);
                decimal productPrice = decimal.Parse(tokens[3]);

                Box product = new Box();
                product.SerialNumber = serialNumber;
                product.Item.Name = productName;
                product.Item.Price = productPrice;
                product.Quantity = quontity;
                product.PriceForBox = quontity * productPrice;

                boxes.Add(product);
            }

            foreach (var box in boxes.OrderByDescending(b => b.PriceForBox))
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f02}: {box.Quantity}");
                Console.WriteLine($"-- ${box.PriceForBox:f02}");                
            }
        }
    }
}

