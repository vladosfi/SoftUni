using System;
using System.Linq;

namespace _03.Stack
{
    class StartUp
    {
        public static void Main()
        {
            CustomStack<string> customStack = new CustomStack<string>();
            string input = Console.ReadLine();

            while (input != "END")
            {
                //string[] tokens = input.Split(" ", 2);
                string[] tokens = input.Split(new char[] { ' ', ','},StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                if (command == "Push")
                {
                    customStack.Push(tokens.Skip(1).ToList());
                }
                else if (command == "Pop")
                {
                    try
                    {
                        customStack.Pop();
                    }
                    catch (ArgumentException message)
                    {
                        Console.WriteLine(message.Message);
                    }
                }

                input = Console.ReadLine();
            }


            for (int i = 0; i < 2; i++)
            {
                foreach (var item in customStack)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
