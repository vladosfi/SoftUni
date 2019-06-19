using System;
using System.Linq;

namespace IteratorsAndComparators
{
    class StartUp
    {
        static void Main()
        {
            string input = Console.ReadLine();
            CustomStack<string> stack = new CustomStack<string>();
            
            while (input != "END")
            {
                string[] tokens = input.Split(" ", 2);
                string command = tokens[0];

                if (command == "Push")
                {
                    string[] elements = tokens[1].Split(", ", StringSplitOptions.RemoveEmptyEntries);
                    stack.Push(elements);
                }
                else if (command == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (IndexOutOfRangeException message)
                    {
                        Console.WriteLine(message.Message);
                    }
                    
                }
                input = Console.ReadLine();
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
