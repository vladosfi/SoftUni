using System;
using System.Linq;

namespace IteratorsAndComparators
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            ListyIterator<string> iterator = new ListyIterator<string>();

            while (command != "END")
            {
                string[] tokens = command.Split();
                command = tokens[0];

                if (command == "Create")
                {
                    tokens = tokens.Skip(1).ToArray();
                    iterator.Create(tokens);
                }
                else if (command == "Move")
                {
                    Console.WriteLine(iterator.Move());
                }
                else if (command == "Print")
                {
                    try
                    {
                        iterator.Print();
                    }
                    catch (InvalidOperationException error)
                    {
                        Console.WriteLine(error.Message);
                    }
                    
                }
                else if (command == "PrintAll")
                {
                    Console.WriteLine(string.Join(" ",iterator));
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(iterator.HasNext());
                }

                command = Console.ReadLine();
            }
        }
    }
}
