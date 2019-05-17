using System;

namespace _08.Choreography
{
    class Choreography
    {
        static void Main()
        {
            int steps = int.Parse(Console.ReadLine());
            int dancers = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            double stepsPerDay = Math.Ceiling((((double)steps / days) / steps) * 100);
            double stepsPerDancer = stepsPerDay / dancers;

            if (stepsPerDay <= 13)
            {
                Console.WriteLine($"Yes, they will succeed in that goal! {stepsPerDancer:F02}%.");
            }
            else
            {
                Console.WriteLine($"No, They will not succeed in that goal! Required {stepsPerDancer:F02}% steps to be learned per day.");
            }

        }
    }
}
