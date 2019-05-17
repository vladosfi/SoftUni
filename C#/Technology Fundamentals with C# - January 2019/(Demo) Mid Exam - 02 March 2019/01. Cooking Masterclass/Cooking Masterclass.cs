using System;
using System.Threading;

namespace _01._Cooking_Masterclass
{
    class Program
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            decimal budget = decimal.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            decimal floorPrice = decimal.Parse(Console.ReadLine());
            decimal eggPrice = decimal.Parse(Console.ReadLine());
            decimal apronPrice = decimal.Parse(Console.ReadLine());

            eggPrice *= students * 10;
            apronPrice *= students + Math.Ceiling(students * 0.2m);
            floorPrice *= (students - (students / 5));
            decimal expence = eggPrice + apronPrice + floorPrice;

            if (budget >= expence)
            {
                Console.WriteLine($"Items purchased for {expence:f02}$.");
            }
            else
            {
                Console.WriteLine($"{(expence - budget):f02}$ more needed.");
            }

        }
    }
}
