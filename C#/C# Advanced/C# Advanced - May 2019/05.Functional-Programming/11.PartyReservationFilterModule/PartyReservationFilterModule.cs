using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PartyReservationFilterModule
{
    class PartyReservationFilterModule
    {
        static void Main()
        {
            Func<string, string, bool> startsWith = (name, startText) => !name.StartsWith(startText);
            Func<string, string, bool> endWith = (name, startText) => !name.EndsWith(startText);
            Func<string, int, bool> lengthWith = (name, len) => name.Length != len;
            Func<string, string, bool> contains = (name, text) => !name.Contains(text);
            Action<string[]> print = guestsComming => Console.WriteLine(string.Join(" ", guestsComming));

            string[] names = Console.ReadLine()
                .Split();

            string filter = Console.ReadLine();
            List<string> filters = new List<string>();

            while (filter!= "Print")
            {
                string[] filterInfo = filter.Split(";");
                string action = filterInfo[0];

                if (action == "Add filter")
                {
                    filters.Add($"{filterInfo[1]};{filterInfo[2]}");
                }
                else
                {
                    filters.Remove($"{filterInfo[1]};{filterInfo[2]}");
                }

                filter = Console.ReadLine();
            }

            foreach (var currentFilter in filters)
            {
                string[] currentFilterInfo = currentFilter.Split(";");
                string action = currentFilterInfo[0];
                string actionParam = currentFilterInfo[1];


                if (action == "Starts with")
                {
                    names = names.Where(n => startsWith(n, actionParam)).ToArray();
                }
                else if (action == "Ends with")
                {
                    names = names.Where(n => endWith(n, actionParam)).ToArray();
                }
                else if (action == "Length")
                {
                    names = names.Where(n => lengthWith(n, int.Parse(actionParam))).ToArray();
                }
                else if (action == "Contains")
                {
                    names = names.Where(n => contains(n, actionParam)).ToArray();
                }
            }

            print(names);
        }
    }
}
