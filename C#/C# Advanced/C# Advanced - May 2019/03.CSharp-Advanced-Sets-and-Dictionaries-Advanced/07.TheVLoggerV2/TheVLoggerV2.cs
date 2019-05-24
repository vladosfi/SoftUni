using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheVLoggerV2
{
    class TheVLoggerV2
    {
        static void Main()
        {
            var vloggers = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string input = Console.ReadLine();

            while (input.ToLower() != "statistics")
            {
                if (input.Contains("joined"))
                {
                    string[] tokens = input.Split();
                    string vlogger = tokens[0];

                    if (!vloggers.ContainsKey(vlogger))
                    {
                        vloggers.Add(vlogger, new Dictionary<string, HashSet<string>>());
                        vloggers[vlogger].Add("followers", new HashSet<string>());
                        vloggers[vlogger].Add("following", new HashSet<string>());
                    }
                }
                else if (input.Contains("followed"))
                {
                    string[] tokens = input.Split();
                    string firstVlogger = tokens[0];
                    string secondVlogger = tokens[2];

                    if (!vloggers.ContainsKey(firstVlogger) ||
                        !vloggers.ContainsKey(secondVlogger) ||
                        firstVlogger == secondVlogger)
                    {
                        input = Console.ReadLine();
                        continue;                        
                    }

                    vloggers[secondVlogger]["followers"].Add(firstVlogger);
                    vloggers[firstVlogger]["following"].Add(secondVlogger);
                }

                input = Console.ReadLine();
            }
            
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            var sortedVloggers = vloggers
                .OrderByDescending(x => x.Value["followers"].Count())
                .ThenBy(x => x.Value["following"].Count());

            int counter = 0;
            foreach (var kvp in sortedVloggers)
            {
                counter++;

                int followersCount = kvp.Value["followers"].Count;
                int followingCount = kvp.Value["following"].Count;

                Console.WriteLine($"{counter}. {kvp.Key} : {followersCount} followers, {followingCount} following");

                if (counter == 1)
                {
                    var followersCollection = kvp.Value["followers"].OrderBy(x => x);
                    foreach (var follower in followersCollection)
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

            }
        }
    }
}
