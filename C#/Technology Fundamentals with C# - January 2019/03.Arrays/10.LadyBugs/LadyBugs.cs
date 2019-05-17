using System;
using System.Linq;

namespace _10.LadyBugs
{
    class LadyBugs
    {
        static void Main()
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] field = new int[fieldSize];
            int[] ladyBugIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();


            for (int i = 0; i < ladyBugIndexes.Length; i++)
            {
                if (ladyBugIndexes[i] >= 0 && ladyBugIndexes[i] < field.Length)
                {
                    field[ladyBugIndexes[i]] = 1;
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] tokens = input.Split();
                long ladyBugIndex = long.Parse(tokens[0]);
                string direction = tokens[1];
                long distance = long.Parse(tokens[2]);

                if (ladyBugIndex >= 0 &&
                    ladyBugIndex < field.Length &&
                    field[ladyBugIndex] == 1)
                {
                    field[ladyBugIndex] = 0;

                    if (direction == "right"
                        && distance + ladyBugIndex < field.Length)
                    {
                        ladyBugIndex = distance + ladyBugIndex;

                        while (field.Length > ladyBugIndex)
                        {
                            if (field[ladyBugIndex] == 0)
                            {
                                field[ladyBugIndex] = 1;
                                break;
                            }
                            else
                            {
                                ladyBugIndex += distance;
                            }
                        }
                    }
                    else if (direction == "left" &&
                        ladyBugIndex - distance >= 0)
                    {
                        ladyBugIndex = ladyBugIndex - distance;

                        while (ladyBugIndex >= 0)
                        {
                            if (field[ladyBugIndex] == 0)
                            {
                                field[ladyBugIndex] = 1;
                                break;
                            }
                            else
                            {
                                ladyBugIndex -= distance;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", field));
        }
    }
}
