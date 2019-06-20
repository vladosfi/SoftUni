using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ClubParty
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int hallsCapacity = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Stack<string> elements = new Stack<string>(input);
            List<int> allGroup = new List<int>();
            Queue<string> halls = new Queue<string>();

            while (elements.Count > 0)
            {
                string element = elements.Pop();

                if (int.TryParse(element,out int company))
                {
                    if (halls.Count == 0)
                    {
                        continue;
                    }

                    if (allGroup.Sum() + company > hallsCapacity)
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", allGroup)}");
                        allGroup.Clear();
                    }

                    if (halls.Count == 0)
                    {
                        continue;
                    }

                    allGroup.Add(company);
                }
                else
                {
                    halls.Enqueue(element);
                }                
            }


        }
    }
}
