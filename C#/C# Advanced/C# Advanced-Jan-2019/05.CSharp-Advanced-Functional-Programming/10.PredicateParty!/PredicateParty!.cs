using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty_
{
    class Program
    {
        static void Main()
        {
            List<string> guests = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            Action<List<string>> print = names => Console.WriteLine(string.Join(", ", names) + " are going to the party!");
            Predicate<string> predicate;

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "Party!")
                {
                    break;
                }

                string command = input[0];
                string filterCommand = input[1];
                string criteriaReq = input[2];

                predicate = GetPredicate(filterCommand, criteriaReq);

                if (command == "Remove")
                {
                    guests.RemoveAll(predicate);
                }
                else if (command == "Double")
                {                    
                    var newGuests = guests.FindAll(predicate);

                    foreach (var name in newGuests)
                    {
                        int index = guests.IndexOf(name);
                        guests.Insert(index + 1, name);
                    }
                }
            }

            if (guests.Any())
            {
                print(guests);
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string filterCommand, string criteriaReq)
        {
            if (filterCommand == "StartsWith")
            {
                return x => x.StartsWith(criteriaReq);
            }
            else if (filterCommand == "EndsWith")
            {
                return x => x.EndsWith(criteriaReq);
            }
            else if (filterCommand == "Length")
            {
                return x => x.Length == int.Parse(criteriaReq);
            }

            return null;
        }
    }
}
