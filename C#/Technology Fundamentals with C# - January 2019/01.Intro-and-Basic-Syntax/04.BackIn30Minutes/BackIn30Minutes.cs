using System;

namespace _04.BackIn30Minutes
{
    class BackIn30Minutes
    {
        static void Main()
        {
            int hour = int.Parse(Console.ReadLine());
            int min = int.Parse(Console.ReadLine());

            min += 30;

            if (min >= 60)
            {
                min -= 60;
                hour++;

                if (hour == 24)
                {
                    hour = 0;
                }
            }

            Console.WriteLine($"{hour}:{min:D02}");
        }
    }
}
