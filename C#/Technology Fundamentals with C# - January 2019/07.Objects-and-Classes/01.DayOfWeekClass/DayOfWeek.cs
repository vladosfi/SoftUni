using System;
using System.Globalization;

namespace _01.DayOfWeekClass
{
    class DayOfWeek
    {
        static void Main()
        {
            DateTime dayOfWeek = DateTime.ParseExact(Console.ReadLine(), "d-M-yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine(dayOfWeek.DayOfWeek);
        }
    }
}
