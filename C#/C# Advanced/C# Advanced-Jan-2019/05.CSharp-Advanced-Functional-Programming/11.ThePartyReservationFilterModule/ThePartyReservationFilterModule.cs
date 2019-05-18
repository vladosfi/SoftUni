using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ThePartyReservationFilterModule
{
    class ThePartyReservationFilterModule
    {
        static void Main()
        {
            List<string> guests = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> notGoing = new List<string>();

            Func<List<string>, string, List<string>> startWith = (g, s) => g.Where(x => x.StartsWith(s)).ToList();
            Func<List<string>, string, List<string>> endWith = (g, e) => g.Where(x => x.EndsWith(e)).ToList();
            Func<List<string>, int, List<string>> length = (g, e) => g.Where(x => x.Length == e).ToList();
            Func<List<string>, string, List<string>> contains = (g, e) => g.Where(x => x.Contains(e)).ToList();
            Func<List<string>, List<string>, List<string>> prepairPrint = (names, notGo) => names.Where(x => !notGo.Contains(x)).ToList();
            Action<List<string>> print = names => Console.WriteLine(string.Join(" ", names));

            while (true)
            {
                string[] input = Console.ReadLine().Split(";");

                if (input[0] == "Print")
                {
                    break;
                }

                string command = input[0];
                string filterCommand = input[1];
                string criteriaReq = input[2];
                List<string> tmpFilter = new List<string>();

                if (filterCommand == "Starts with")
                {
                    tmpFilter = startWith(guests, criteriaReq);
                }
                else if (filterCommand == "Ends with")
                {
                    tmpFilter = endWith(guests, criteriaReq);
                }
                else if (filterCommand == "Length")
                {
                    tmpFilter = length(guests, int.Parse(criteriaReq));
                }
                else if (filterCommand == "Contains")
                {
                    tmpFilter = contains(guests, criteriaReq);
                }


                foreach (var name in tmpFilter)
                {
                    if (command == "Add filter")
                    {
                        notGoing.Add(name);
                    }
                    else if (command == "Remove filter")
                    {
                        notGoing.Remove(name);
                    }
                }
            }

            if (guests.Any())
            {
                guests = prepairPrint(guests, notGoing);
                print(guests);
            }
        }
    }
}
