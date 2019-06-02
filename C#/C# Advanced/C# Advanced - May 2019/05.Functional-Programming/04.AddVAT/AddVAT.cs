using System;
using System.Linq;
using System.Threading;

namespace _04.AddVAT
{
    class AddVAT
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            Func<string, string> AddVAT = n => $"{(double.Parse(n) * 1.2):F02}";

            Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(AddVAT)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
