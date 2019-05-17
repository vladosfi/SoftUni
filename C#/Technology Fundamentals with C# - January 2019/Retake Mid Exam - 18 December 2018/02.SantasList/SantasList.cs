using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SantasList
{
    class SantasList
    {
        static void Main()
        {
            List<string> noisyKids = Console.ReadLine().Split("&").ToList();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split();
                string command = tokens[0];

                if (command == "Finished!")
                {
                    break;
                }

                if (command == "Bad")
                {
                    string kidName = tokens[1];

                    if (!noisyKids.Contains(kidName))
                    {
                        noisyKids.Insert(0, kidName);
                    }
                }
                else if (command == "Good")
                {
                    string kidName = tokens[1];

                    if (noisyKids.Contains(kidName))
                    {
                        noisyKids.Remove(kidName);
                    }
                }
                else if (command == "Rename")
                {
                    string oldName = tokens[1];
                    string newName = tokens[2];
                    int indexOfKid = noisyKids.IndexOf(oldName);

                    if (indexOfKid != -1)
                    {
                        noisyKids[indexOfKid] = newName;
                    }
                }
                else if (command == "Rearrange")
                {
                    string kidName = tokens[1];

                    if (noisyKids.Contains(kidName))
                    {
                        noisyKids.Remove(kidName);
                        noisyKids.Insert(noisyKids.Count, kidName);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", noisyKids));
        }
    }
}
