using System;

namespace _05.TimePlus15
{
    class TimePlus15
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            minutes = minutes + 15;

            if (minutes > 59)
            {
                minutes = minutes % 60;
                hours = hours + 1;
            }
            if (hours > 23)
            {
                hours = hours % 24;
            }

            Console.WriteLine($"{hours}:{minutes:0#}");
        }
    }
}
