using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Concert
{
    class Concert
    {
        static void Main()
        {
            Dictionary<string, List<string>> bandMembers = new Dictionary<string, List<string>>();
            Dictionary<string, int> bandTime = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "start of concert")
                {
                    break;
                }

                string[] tokens = input.Split("; ");
                string command = tokens[0];
                string bandName = tokens[1];

                if (command == "Add")
                {
                    List<string> members = tokens[2].Split(", ").ToList();

                    if (!bandMembers.ContainsKey(bandName))
                    {
                        bandMembers.Add(bandName, new List<string>());
                    }

                    for (int i = 0; i < members.Count; i++)
                    {
                        if (!bandMembers[bandName].Contains(members[i]))
                        { 
                            bandMembers[bandName].Add(members[i]);
                        }

                    }

                    

                }
                else if (command == "Play")
                {
                    int time = int.Parse(tokens[2]);

                    if (!bandTime.ContainsKey(bandName))
                    { 
                        bandTime.Add(bandName, 0);
                    }

                    bandTime[bandName] += time;
                }

            }
            
            Console.WriteLine($"Total time: {bandTime.Select(x=>x.Value).Sum()}");

            foreach (var kvp in bandTime.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }

            string selectedBand = Console.ReadLine();
            Console.WriteLine(selectedBand);

            foreach (var kvp in bandMembers.Where(x => x.Key == selectedBand))
            {
                
                foreach (var member in kvp.Value)
                {
                    Console.WriteLine($"=> {member}");
                }
            }
        }
    }
}
