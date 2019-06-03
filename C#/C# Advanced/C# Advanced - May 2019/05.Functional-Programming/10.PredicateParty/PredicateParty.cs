using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty
{
    class PredicateParty
    {
        static void Main()
        {
            Func<string, string, string, bool> RemoveFilter = (string nameToCheck, string filterType, string filter) =>
             {
                 if (filterType == "StartsWith" && nameToCheck.StartsWith(filter))
                 {
                     return false;
                 }
                 else if (filterType == "EndsWith" && nameToCheck.EndsWith(filter))
                 {
                     return false;
                 }
                 else if (filterType == "Lenght" && nameToCheck.Length == int.Parse(filter))
                 {
                     return false;
                 }

                 return true;
             };


            Func<List<string>, string, string, List<string>> DoubleFilter = (List<string> names, string filterType, string filter) =>
            {

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

                if (command == "Remove")
                {
                    guests = guests.Where(n => RemoveFilter(n, filterType, filter)).ToList();
                }
                else if (command == "Double")
                {
                    guests = DoubleFilter(guests, filterType, filter);
                }

                input = Console.ReadLine();
            }
        }
    }
}
