using System;
using System.Collections.Generic;

namespace _03.HouseParty
{
    class HouseParty
    {
        static void Main()
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            List<string> listOfGuests = new List<string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string command = Console.ReadLine();

                if (command.Contains("is going!"))
                {
                    string[] tokens = command.Split();

                    if (listOfGuests.Contains(tokens[0]))
                    {
                        Console.WriteLine($"{tokens[0]} is already in the list!");
                    }
                    else
                    {
                        listOfGuests.Add(tokens[0]);
                    }
                }
                else
                {
                    string[] tokens = command.Split();

                    if (listOfGuests.Contains(tokens[0]))
                    {
                        listOfGuests.Remove(tokens[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{tokens[0]} is not in the list!");
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, listOfGuests));
        }
    }
}
