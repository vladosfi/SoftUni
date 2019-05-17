using System;
using System.Linq;

namespace _03.PresentDelivery
{
    class PresentDelivery
    {
        static void Main()
        {
            int[] houses = Console.ReadLine().Split("@").Select(int.Parse).ToArray();
            int lastPositionIndex = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Merry Xmas!")
                {
                    break;
                }

                string[] tokens = command.Split();
                command = tokens[0];

                if (command == "Jump")
                {
                    int jumpLen = int.Parse(tokens[1]);
                    int counter = 0;
                   
                    for (int i = lastPositionIndex; i < houses.Length; i++)
                    {
                        lastPositionIndex = i;
                        
                        if (counter == jumpLen)
                        {
                            if (houses[i] > 0)
                            {
                                houses[i] -= 2;
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"House {i} will have a Merry Christmas.");
                                break;
                            }
                        }
                        if (i == houses.Length - 1)
                        {
                            i = -1;
                        }
                        counter++;
                    }
                }

            }

            Console.WriteLine($"Santa's last position was {lastPositionIndex}.");

            int housesCount = 0;
            foreach (var house in houses)
            {
                if (house != 0)
                {
                    housesCount++;
                }
            }

            if (housesCount == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Santa has failed {housesCount} houses.");
            }
        }
    }
}
