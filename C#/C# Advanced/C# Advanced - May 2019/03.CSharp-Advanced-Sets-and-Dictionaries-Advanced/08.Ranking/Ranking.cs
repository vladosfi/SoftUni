using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Ranking
    {
        static void Main()
        {
            var contests = new Dictionary<string, string>();
            var userPoints = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input.ToLower() != "end of contests")
            {
                string[] tokens = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contest = tokens[0];
                string password = tokens[1];

                if (!contests.ContainsKey(contest))
                {
                    contests[contest] = password;
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "end of submissions")
            {
                string[] tokens = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = tokens[0];
                string password = tokens[1];

                if (!(contests.ContainsKey(contest) && contests[contest] == password))
                {
                    input = Console.ReadLine();
                    continue;
                }

                string user = tokens[2];
                int points = int.Parse(tokens[3]);

                if (!userPoints.ContainsKey(user))
                {
                    userPoints.Add(user, new Dictionary<string, int>());
                }

                if (!userPoints[user].ContainsKey(contest))
                {
                    userPoints[user].Add(contest, 0); 
                }

                if (userPoints[user][contest] < points)
                {
                    userPoints[user][contest] = points;
                }

                input = Console.ReadLine();
            }

            var bestCandidate = userPoints.OrderByDescending(x => x.Value.Values.Sum()).FirstOrDefault();

            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value.Values.Sum()} points.");
            Console.WriteLine("Ranking:");

            foreach (var kvp in userPoints.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key}");

                foreach (var innerKvp in kvp.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {innerKvp.Key} -> {innerKvp.Value}");
                }
            }
        }
    }
}
