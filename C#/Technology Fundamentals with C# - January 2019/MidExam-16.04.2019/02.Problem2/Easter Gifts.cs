using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Problem2
{
    class Program
    {
        static void Main()
        {
            List<string> gifts = Console.ReadLine().Split().ToList();

            while (true)
            {
                string command = Console.ReadLine();
                
                if (command == "No Money")
                {
                    break;
                }

                string[] tokens = command.Split();
                command = tokens[0];
                string gift = tokens[1];

                if (command == "OutOfStock")
                {
                    int indexOfGift = gifts.IndexOf(gift);

                    while (indexOfGift != -1)
                    {
                        gifts[indexOfGift] = "None";
                        indexOfGift = gifts.IndexOf(gift);
                    }
                }
                else if (command == "Required")
                {
                    int index = int.Parse(tokens[2]);

                    if (index >= 0 && index < gifts.Count)
                    {
                        gifts[index] = gift;
                    }
                }
                else if (command == "JustInCase")
                {
                    gifts[gifts.Count-1] = gift;
                }
            }

            Console.WriteLine(string.Join(" ", gifts.Where(x=>x != "None")));
        }
    }
}
