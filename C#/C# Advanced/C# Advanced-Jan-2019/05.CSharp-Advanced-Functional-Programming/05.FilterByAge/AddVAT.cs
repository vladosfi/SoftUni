using System;
using System.Linq;
using System.Threading;

namespace _05.FilterByAge
{
    class AddVAT
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            Func<string, double> addVat = x => double.Parse(x) * 1.2;

            double[] numbers = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(addVat)
                .ToArray();

            foreach (var num in numbers)
            {
                Console.WriteLine($"{num:f2}");
            }
        }
    }
}
