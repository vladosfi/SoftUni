using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
    class FilterByAge
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var persons = new List<KeyValuePair<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                KeyValuePair<string, int> person = new KeyValuePair<string, int>(tokens[0], int.Parse(tokens[1]));
                persons.Add(person);
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string[] format = Console.ReadLine().Split();

            persons.Where(p => condition == "younger" ? p.Value < age : p.Value >= age)
                .ToList()
                .ForEach(p => Print(p, format));

            void Print(KeyValuePair<string, int> person, string[] printFormat)
            {
                if (printFormat.Count() == 2)
                {
                    Console.WriteLine(
                         printFormat[0] == "name" ?
                         $"{person.Key} - {person.Value}" :
                         $"{person.Value} - {person.Key}");
                }
                else
                {
                    Console.WriteLine(
                        printFormat[0] == "name" ?
                        $"{person.Key}":
                        $"{person.Value}"
                        );
                }
            }



        }
    }
}
