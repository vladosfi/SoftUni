using System;

namespace GenericBoxOfInteger
{
    class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var gen = new Box<int>(int.Parse(Console.ReadLine()));
                Console.WriteLine($"{gen}");
            }
        }
    }
}
