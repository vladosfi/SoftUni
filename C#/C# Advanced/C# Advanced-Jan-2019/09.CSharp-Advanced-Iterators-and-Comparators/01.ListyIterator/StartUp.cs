using System;
using System.Linq;

namespace _01.ListyIterator
{
    class StartUp
    {
        static void Main()
        {
            string input = Console.ReadLine();
            ListyIterator<string> list = null;

            while (input != "END") 
            {
                string[] tokens = input.Split();
                string command = tokens[0];
                

                if (command == "Create")
                {
                    list = new ListyIterator<string>(tokens.Skip(1).ToArray());
                }
                else if (command == "Move")
                {
                    Console.WriteLine(list.Move());
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(list.HasNext());
                }
                else if (command == "Print")
                {
                    try
                    {
                        Console.WriteLine(list.Print());
                    }
                    catch (ArgumentException message)
                    {
                        Console.WriteLine(message.Message);
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
