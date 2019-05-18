using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheVLogger_v2
{
    class TheVlogger
    {
        static void Main()
        {
            var vloggers = new Dictionary<string, HashSet<string>>();
            var userFollowing = new Dictionary<string, HashSet<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Statistics")
                {
                    break;
                }

                if (input.Contains("joined The V-Logger"))
                {
                    var tokens = input.Split();
                    string vlogger = tokens[0];

                    if (!vloggers.ContainsKey(vlogger))
                    {
                        vloggers[vlogger] = new HashSet<string>();
                        userFollowing[vlogger] = new HashSet<string>();
                    }
                }
                else if (input.Contains(" followed "))
                {
                    var tokens = input.Split(" followed ");
                    string userFallower = tokens[0];
                    string userFallowed = tokens[1];

                    if (vloggers.ContainsKey(userFallower) && vloggers.ContainsKey(userFallowed)
                        && userFallower != userFallowed)
                    {
                        vloggers[userFallowed].Add(userFallower);
                        userFollowing[userFallower].Add(userFallowed);
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            var topVlogger = vloggers
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => userFollowing[x.Key].Count).FirstOrDefault();

            Console.WriteLine($"1. {topVlogger.Key} : {topVlogger.Value.Count} followers, " +
                $"{userFollowing[topVlogger.Key].Count} following");

            foreach (var user in topVlogger.Value.OrderBy(x=>x))
            {
                Console.WriteLine($"*  {user}");
            }

            int count = 1;

            foreach (var kvp in vloggers
                .Where(x=> x.Key != topVlogger.Key)
                .OrderByDescending(x=>x.Value.Count)
                .ThenBy(x=> userFollowing[x.Key].Count))
            {
                count++;
                Console.WriteLine($"{count}. {kvp.Key} : {kvp.Value.Count} followers, {userFollowing[kvp.Key].Count} following");
            }
        }
    }
}
