using System;

namespace _11.MultiplicationTable2._0
{
    class MultiplicationTable2
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int times = int.Parse(Console.ReadLine());

            Console.WriteLine($"{n} X {times} = {n * times}");

            for (int i = times+1; i <= 10; i++)
            {
                Console.WriteLine($"{n} X {i} = {n * i}");
            }
        }
    }
}
