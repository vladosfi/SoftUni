using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ListManipulationAdvanced
{
    class ListManipulationAdvanced
    {
        static void Main()
        {
            List<long> numbers = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToList();
            List<long> numbersCopy = new List<long>();

            foreach (var element in numbers)
            {
                numbersCopy.Add(element);
            }

            while (true)
            {
                string[] tockens = Console.ReadLine()
                    .Split()
                    .ToArray();

                string command = tockens[0];

                if (command.ToLower() == "end")
                {
                    break;
                }

                switch (command)
                {
                    case "Add":
                        numbers.Add(int.Parse(tockens[1]));
                        break;
                    case "Remove":
                        numbers.Remove(int.Parse(tockens[1]));
                        break;
                    case "RemoveAt":
                        numbers.RemoveAt(int.Parse(tockens[1]));
                        break;
                    case "Insert":
                        numbers.Insert(int.Parse(tockens[2]), int.Parse(tockens[1]));
                        break;
                    case "Contains":
                        string containNumber = numbers.Contains(int.Parse(tockens[1])) ? "Yes" : "No such number";
                        Console.WriteLine(containNumber);
                        break;
                    case "PrintEven":
                        Console.WriteLine(string.Join(" ", numbers.Where(x => x % 2 == 0).ToList()));
                        break;
                    case "PrintOdd":
                        Console.WriteLine(string.Join(" ", numbers.Where(x => x % 2 != 0).ToList()));
                        break;
                    case "GetSum":
                        Console.WriteLine(numbers.Sum());
                        break;
                    case "Filter":

                        string condition = tockens[1];
                        int value = int.Parse(tockens[2]);
                        List<long> conditionalList = GetConditionalList(value, condition, numbers);
                        Console.WriteLine(string.Join(" ", conditionalList));
                        break;
                    default:
                        break;
                }
            }

            bool isDifferent = false;

            if (numbersCopy.Count != numbers.Count)
            {
                isDifferent = true;
            }
            else
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] != numbers[i])
                    {
                        isDifferent = true;
                        break;
                    }
                }
            }

            if (isDifferent)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
            
        }

        private static List<long> GetConditionalList(int value, string condition, List<long> numbers)
        {
            List<long> conditionalList = new List<long>();

            if (condition == "<")
            {
                conditionalList = numbers.Where(x => x < value).ToList();
            }
            else if (condition == ">")
            {
                conditionalList = numbers.Where(x => x > value).ToList();
            }
            else if (condition == ">=")
            {
                conditionalList = numbers.Where(x => x >= value).ToList();
            }
            else if (condition == "<=")
            {
                conditionalList = numbers.Where(x => x <= value).ToList();
            }

            return conditionalList;
        }
    }
}
