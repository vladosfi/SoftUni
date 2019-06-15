using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheVLogger
{
    class TheVLogger
    {
        static void Main()
        {
            var vloggersFollowing = new Dictionary<string, HashSet<string>>();
            var vloggersFollowers = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input.ToLower() != "statistics")
            {
                string[] tokens;

                if (input.Contains("joined The V-Logger"))
                {
                    tokens = input.Split();
                    string vloger = tokens[0];

                    if (!vloggersFollowing.ContainsKey(vloger))
                    {
                        vloggersFollowing.Add(vloger, new HashSet<string>());
                    }

                    if (!vloggersFollowers.ContainsKey(vloger))
                    {
                        vloggersFollowers.Add(vloger, 0);
                    }
                }
                else if (input.Contains(" followed "))
                {
                    tokens = input.Split();
                    string follower = tokens[0];
                    string following = tokens[2];

                    if (vloggersFollowing.ContainsKey(follower) &&
                        vloggersFollowing.ContainsKey(following) &&
                        follower != following)
                    {
                        if (!vloggersFollowing[following].Contains(follower))
                        {
                            vloggersFollowing[following].Add(follower);
                            vloggersFollowers[follower]++;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vloggersFollowing.Count} vloggers in its logs.");
            var sortedVloggers = vloggersFollowing
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => vloggersFollowers[x.Key]);

            int count = 0;
            foreach (var kvp in sortedVloggers)
            {
                count++;

                Console.WriteLine($"{count}. {kvp.Key} : {kvp.Value.Count} followers, {vloggersFollowers[kvp.Key]} following");
                if (count == 1)
                {
                    foreach (var name in kvp.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {name}");
                    }
                }
            }

        }
    }
}
