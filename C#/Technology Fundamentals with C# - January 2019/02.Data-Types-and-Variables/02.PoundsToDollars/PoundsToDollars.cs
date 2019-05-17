using System;
using System.Threading;

namespace _02.PoundsToDollars
{
    class PoundsToDollars
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            decimal pounds = decimal.Parse(Console.ReadLine());

            Console.WriteLine($"{pounds * 1.31m:F03}");
        }
    }
}
