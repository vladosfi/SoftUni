using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class TruckTour
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> pumps = new Queue<int[]>();
            int indexOfPomp = 0;

            for (int i = 0; i < n; i++)
            {
                int[] petrolPump = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                pumps.Enqueue(petrolPump);
            }

            while (true)
            {
                int tankAmount = 0;

                foreach (var pump in pumps)
                {
                    int fuelAmount = pump[0];
                    int distance = pump[1];
                    tankAmount += fuelAmount - distance;

                    if (tankAmount < 0)
                    {
                        pumps.Enqueue(pumps.Dequeue());
                        indexOfPomp++;
                        break;
                    }
                }

                if (tankAmount >= 0)
                {
                    break;
                }
            }



            Console.WriteLine(indexOfPomp);
        }
    }
}
