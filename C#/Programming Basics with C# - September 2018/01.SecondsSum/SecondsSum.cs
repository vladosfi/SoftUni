using System;

namespace _01.SecondsSum
{
    class SecondsSum
    {
        static void Main()
        {
            byte seconds;
            int sum = 0;

            for (int i = 0; i < 3; i++)
            {
                seconds = byte.Parse(Console.ReadLine());
                sum = sum + seconds;
            }

            if (sum >= 60)
            {
                Console.WriteLine($"{(sum / 60)}:{(sum % 60):0#}");
            }
            else
            {
                Console.WriteLine($"0:{sum:0#}");
            }
            
        }
    }
}
