using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LastStop
{
    class LastStop
    {
        static void Main()
        {
            List<int> paintings = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(" ");

                if (tokens[0].ToLower() == "end")
                {
                    break;
                }

                string command = tokens[0];
                int paintingNumber = -1;
                int index = -1;

                switch (command)
                {
                    case "Change":
                        paintingNumber = int.Parse(tokens[1]);
                        index = paintings.IndexOf(paintingNumber);
                        if (index != -1)
                        {
                            int changedNumber = int.Parse(tokens[2]);
                            paintings[index] = changedNumber;
                        }
                        break;
                    case "Hide":
                        paintingNumber = int.Parse(tokens[1]);
                        index = paintings.IndexOf(paintingNumber);

                        if (index != -1)
                        {
                            paintings.Remove(paintingNumber);
                        }
                        break;
                    case "Switch":
                        paintingNumber = int.Parse(tokens[1]);
                        index = paintings.IndexOf(paintingNumber);
                        int paintingNumber2 = int.Parse(tokens[2]);
                        int index2 = paintings.IndexOf(paintingNumber2);

                        if (index != -1 && index2 != -1)
                        {
                            int tempPaintingNumber = paintings[index];
                            paintings[index] = paintings[index2];
                            paintings[index2] = tempPaintingNumber;
                        }
                        break;
                    case "Insert":
                        int place = int.Parse(tokens[1]) + 1;
                        paintingNumber = int.Parse(tokens[2]);
                        if (place >=0 && place < paintings.Count)
                        {
                            paintings.Insert(place, paintingNumber);
                        }
                        break;
                    case "Reverse":
                        paintings.Reverse();
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", paintings));
        }
    }
}
