using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty
{
    class PredicateParty
    {
        static void Main()
        {
            Func<string, string, bool> startsWith = (name, startText) => name.StartsWith(startText);
            Func<string, string, bool> endWith = (name, startText) => name.EndsWith(startText);
            Func<string, int, bool> lengthWith = (name, len) => name.Length == len;
            Action<List<string>> print = guestsComming =>
            {
                if (guestsComming.Count > 0)
                {
                    Console.WriteLine($"{string.Join(", ", guestsComming)} are going to the party!");
                }
                else
                {
                    Console.WriteLine("Nobody is going to the party!");
                }
            };

            List<string> guests = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "Party!")
            {
                string[] tokens = input.Split(" ");
                string command = tokens[0];
                string filterType = tokens[1];
                string filter = tokens[2];

                List<string> doubleGuests = new List<string>();

                if (filterType == "StartsWith")
                {
                    doubleGuests = guests.Where(n => startsWith(n, filter)).ToList();
                }
                else if (filterType == "EndsWith")
                {
                    doubleGuests = guests.Where(n => endWith(n, filter)).ToList();
                }
                else if (filterType == "Length")
                {
                    doubleGuests = guests.Where(n => lengthWith(n, int.Parse(filter))).ToList();
                }


                for (int i = 0; i < doubleGuests.Count; i++)
                {
                    if (command == "Remove")
                    {
                        guests.Remove(doubleGuests[i]);
                    }
                    else if (command == "Double")
                    {
                        int indexOfGuest = guests.IndexOf(doubleGuests[i]);
                        guests.Insert(indexOfGuest + 1, doubleGuests[i]);
                    }
                }

                input = Console.ReadLine();
            }

            print(guests);

        }
    }
}
