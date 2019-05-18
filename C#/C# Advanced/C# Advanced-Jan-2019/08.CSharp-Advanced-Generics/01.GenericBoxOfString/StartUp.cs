using System;

namespace GenericBoxOfString
{
    class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            

            for (int i = 0; i < n; i++)
            {
                var gen = new Box<string>(Console.ReadLine());
                Console.WriteLine($"{gen}");
            }
            

            
        }
    }
}
