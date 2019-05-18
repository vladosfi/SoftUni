using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheVLogger
{
    class TheVLogger
    {
        static void Main()
        {
            var vloggers = new HashSet<string>();
            var userFollowers = new Dictionary<string, HashSet<string>>();
            var userFollowings = new Dictionary<string, HashSet<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Statistics")
                {
                    break;
                }

                string[] tokens;

                if (input.Contains(" joined The V-Logger"))
                {
                    tokens = input.Split();
                    string vloggername = tokens[0];

                    vloggers.Add(vloggername);

                    if (!userFollowers.ContainsKey(vloggername))
                    {
                        userFollowers[vloggername] = new HashSet<string>();
                    }
                    if (!userFollowings.ContainsKey(vloggername))
                    {
                        userFollowings[vloggername] = new HashSet<string>();
                    }
                }
                else if (input.Contains(" followed "))
                {
                    tokens = input.Split(" followed ");
                    string fallowing = tokens[0];
                    string fallowed = tokens[1];

                    if (fallowing != fallowed
                        && vloggers.Contains(fallowing)
                        && vloggers.Contains(fallowed))
                    {
                        userFollowers[fallowed].Add(fallowing);
                        userFollowings[fallowing].Add(fallowed);
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            int count = 1;
            var topVlogger = userFollowers
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => userFollowings[x.Key].Count)
                .FirstOrDefault();

            Console.WriteLine($"{count}. {topVlogger.Key} : {userFollowers[topVlogger.Key].Count} followers, " +
                $"{userFollowings[topVlogger.Key].Count} following");


            foreach (var topUserFallower in topVlogger.Value.OrderBy(x => x))
            {
                Console.WriteLine($"*  {topUserFallower}");
            }

            foreach (var vlogger in userFollowers
                .Where(x=>x.Key != topVlogger.Key)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => userFollowings[x.Key].Count))
            {
                count++;
                Console.WriteLine($"{count}. {vlogger.Key} : {vlogger.Value.Count} followers, " +
                    $"{userFollowings[vlogger.Key].Count} following");
            }
        }
    }
}
