using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TrainEx
{
    class TrainEx
    {
        private static int maxCapacity;

        static void Main()
        {
            List<int> listOfWagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                string[] tokens = command.Split();
                
                if (tokens[0] == "Add")
                {
                    listOfWagons.Add(int.Parse(tokens[1]));
                }
                else
                {
                    int passangers = int.Parse(tokens[0]);

                    for (int i = 0; i < listOfWagons.Count; i++)
                    {
                        if (listOfWagons[i] + passangers <= maxCapacity)
                        {
                            listOfWagons[i] = listOfWagons[i] + passangers;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", listOfWagons));
        }
    }
}
