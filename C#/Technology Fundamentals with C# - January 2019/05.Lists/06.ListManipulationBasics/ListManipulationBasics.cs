using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ListManipulationBasics
{
    class ListManipulationBasics
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string[] tockens = Console.ReadLine()
                    .Split()
                    .ToArray();

                string command = tockens[0];

                if (command == "end")
                {
                    break;
                }

                switch (command)
                {
                    case "Add":
                        numbers.Add(int.Parse(tockens[1]));
                        break;
                    case "Remove":
                        numbers.RemoveAll(x=>x == int.Parse(tockens[1]));
                        break;
                    case "RemoveAt":
                        numbers.RemoveAt(int.Parse(tockens[1]));
                        break;
                    case "Insert":
                        numbers.Insert(int.Parse(tockens[2]), int.Parse(tockens[1]));
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
