using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Problem3
{
    class Program
    {
        static void Main()
        {
            List<string> shops = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                if (command == "Include")
                {
                    shops.Add(tokens[1]);
                    
                }
                else if (command == "Visit")
                {
                    string subCommand = tokens[1];
                    int count = int.Parse(tokens[2]);

                    if (count > 0 && count <= shops.Count)
                    {
                        if (subCommand.ToLower() == "first")
                        {
                            shops.RemoveRange(0, count);
                        }
                        else if (subCommand.ToLower() == "last")
                        {
                            int startPosition = shops.Count - count;
                            shops.RemoveRange(startPosition, count);
                        }
                    }
                    
                }
                else if (command == "Prefer")
                {
                    int shopIndex1 = int.Parse(tokens[1]);
                    int shopIndex2 = int.Parse(tokens[2]);

                    if (shopIndex1 >= 0 && shopIndex1 < shops.Count
                        && shopIndex2 >= 0 && shopIndex2 < shops.Count)
                    {
                        string shop1 = shops[shopIndex1];
                        shops[shopIndex1] = shops[shopIndex2];
                        shops[shopIndex2] = shop1;
                    }
                    
                }
                else if (command == "Place")
                {
                    int index = int.Parse(tokens[2]) + 1;

                    if (index >= 0 && index <= shops.Count)
                    {
                        shops.Insert(index, tokens[1]);
                    }
                    
                }

            }

            Console.WriteLine("Shops left:");
            Console.WriteLine(string.Join(" ", shops));

        }
    }
}
