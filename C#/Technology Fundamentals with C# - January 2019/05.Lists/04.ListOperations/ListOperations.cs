using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOperations
{
    class ListOperations
    {
        static void Main()
        {
            List<int> listOfIntegers = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command.ToLower() == "end")
                {
                    break;
                }

                string[] tokens = command.Split();
                int index;
                int value;
                int count;

                switch (tokens[0])
                {
                    case "Add":
                        listOfIntegers.Add(int.Parse(tokens[1]));
                        break;
                    case "Insert":
                        index = int.Parse(tokens[2]);
                        value = int.Parse(tokens[1]);

                        if (index >= 0 && index < listOfIntegers.Count)
                        {
                            listOfIntegers.Insert(index, value);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }

                        break;
                    case "Remove":
                        index = int.Parse(tokens[1]);

                        if (index >=0 && index < listOfIntegers.Count)
                        {
                            listOfIntegers.RemoveAt(index);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }

                        break;
                    case "Shift":
                        if (tokens[1] == "left")
                        {
                            count = int.Parse(tokens[2]);
                            ShiftLeft(listOfIntegers, count);
                        }
                        else if (tokens[1] == "right")
                        {
                            count = int.Parse(tokens[2]);
                            ShiftRight(listOfIntegers, count);
                        }
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(string.Join(" ",listOfIntegers));
        }

        private static void ShiftLeft(List<int> listOfIntegers, int count)
        {
            if (count >= listOfIntegers.Count)
            {
                count %= listOfIntegers.Count;
            }

            for (int i = 0; i < count; i++)
            {
                int first = listOfIntegers[0];
                for (int s = 0; s < listOfIntegers.Count - 1; s++)
                {
                    listOfIntegers[s] = listOfIntegers[s + 1];
                }
                listOfIntegers[listOfIntegers.Count - 1] = first;
            }
        }

        private static void ShiftRight(List<int> listOfIntegers, int count)
        {
            if (count >= listOfIntegers.Count)
            {
                count %= listOfIntegers.Count;
            }

            for (int i = 0; i < count; i++)
            {
                int last = listOfIntegers[listOfIntegers.Count - 1];
                for (int s = listOfIntegers.Count - 1; s > 0; s--)
                {
                    listOfIntegers[s] = listOfIntegers[s-1];
                }
                listOfIntegers[0] = last;
            }
        }
    }
}
