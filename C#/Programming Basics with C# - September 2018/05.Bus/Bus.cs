using System;

namespace _05.Bus
{
    class Bus
    {
        static void Main()
        {
            int passengers = int.Parse(Console.ReadLine());
            int busStops = int.Parse(Console.ReadLine());
            int passengersIn = 0;
            int passengersOut = 0;
            

            for (int i = 1; i <= busStops; i++)
            {

                passengersOut = int.Parse(Console.ReadLine());
                passengers = passengers - passengersOut;
                passengersIn = int.Parse(Console.ReadLine());
                passengers = passengers + passengersIn;
                if (i % 2 != 0)
                {
                    passengers = passengers + 2;
                }
                else
                {
                    passengers = passengers - 2;
                }
                if (passengers < 0)
                {
                    passengers = 0;
                }
            }

            Console.WriteLine($"The final number of passengers is : {passengers}");

        }
    }
}
