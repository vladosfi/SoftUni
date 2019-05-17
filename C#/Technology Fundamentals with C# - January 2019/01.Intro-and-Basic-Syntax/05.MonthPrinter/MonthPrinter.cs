using System;

namespace _05.MonthPrinter
{
    class MonthPrinter
    {
        static void Main()
        {
            int month = int.Parse(Console.ReadLine());

            if (month < 1 || month > 12)
            {
                Console.WriteLine("Error!");
            }
            else
            {
                Console.WriteLine(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month));
            }
        }
    }
}
