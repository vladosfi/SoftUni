using System;
using System.Linq;
using System.Threading;

namespace _03.RoundingNumbers
{
    class RoundingNumbers
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            double[] realNumbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            foreach (var number in realNumbers)
            {
                Console.WriteLine($"{number} => {Math.Round(number, 0, MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
