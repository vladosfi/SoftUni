using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Ranking
{
    class Ranking
    {
        static void Main()
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> submissions = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(":");

                if (tokens[0] == "end of contests")
                {
                    break;
                }

                string contest = tokens[0];
                string pass = tokens[1];

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, null);
                }

                contests[contest] = pass;
            }

            while (true)
            {
                string[] tokens = Console.ReadLine().Split("=>");

                if (tokens[0] == "end of submissions")
                {
                    break;
                }

                string contest = tokens[0];
                string pass = tokens[1];

                if (contests.ContainsKey(contest) && contests[contest] == pass)
                {
                    string name = tokens[2];
                    int points = int.Parse(tokens[3]);

                    if (!submissions.ContainsKey(name))
                    {
                        submissions.Add(name, new Dictionary<string, int>());
                    }

                    if (!submissions[name].ContainsKey(contest))
                    {
                        submissions[name].Add(contest,0);
                    }

                    if (submissions[name][contest] < points)
                    {
                        submissions[name][contest] = points;
                    }
                }
            }

            var bestCandidate = submissions.OrderByDescending(x => x.Value.Values.Sum()).FirstOrDefault();

            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value.Values.Sum()} points.");
            Console.WriteLine("Ranking: ");

            foreach (var kvp in submissions.OrderBy(x => x.Key))
            {
                Console.WriteLine(kvp.Key);
                foreach (var kvpInner in kvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {kvpInner.Key} -> {kvpInner.Value}");
                }
            }
        }
    }
}
