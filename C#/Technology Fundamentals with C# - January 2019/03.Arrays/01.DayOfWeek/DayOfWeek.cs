using System;

namespace _01.DayOfWeek
{
    class DayOfWeek
    {
        static void Main()
        {
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            int numberDay = int.Parse(Console.ReadLine()) - 1;

            if (numberDay >= 0 && numberDay <= 6)
            {
                Console.WriteLine(days[numberDay]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }

        }
    }
}
