using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ChangeList
{
    class List
    {
        static void Main()
        {
            List<int> changeList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();


            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                string[] tokens = command.Split();

                if (tokens[0] == "Delete")
                {
                    changeList.RemoveAll(x => x == int.Parse(tokens[1]));
                }
                else if (tokens[0] == "Insert")
                {
                    changeList.Insert(int.Parse(tokens[2]), int.Parse(tokens[1]));
                }
            }

            Console.WriteLine(string.Join(" ",changeList));
        }
    }
}
