using System;

namespace _03.Ferrari
{
    public class StartUp
    {
        static void Main()
        {
            string driverName = Console.ReadLine();

            ICar ferrary = new Ferrari(driverName);

            Console.WriteLine(ferrary);
        }
    }
}
