using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Judge
{
    class Judge
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, int>> contests = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(" -> ");

                if (tokens[0] == "no more time")
                {
                    break;
                }

                string participant = tokens[0];
                string contestName = tokens[1];
                int points = int.Parse(tokens[2]);

                if (!contests.ContainsKey(contestName))
                {
                    contests.Add(contestName, new Dictionary<string, int>());
                }

                if (!contests[contestName].ContainsKey(participant))
                {
                    contests[contestName].Add(participant, 0);
                }

                if (contests[contestName][participant] < points)
                {
                    contests[contestName][participant] = points;
                }
            }

            int counter = 0;

            foreach (var kvp in contests)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Values.Count()} participants");
                counter = 0;
                foreach (var innerKvp in kvp.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    counter++;
                    Console.WriteLine($"{counter}. {innerKvp.Key} <::> {innerKvp.Value}");
                }
            }

            Dictionary<string, int> participants = new Dictionary<string, int>();

            foreach (var kvp in contests)
            {
                foreach (var innerKvp in kvp.Value)
                {
                    if (!participants.ContainsKey(innerKvp.Key))
                    {
                        participants.Add(innerKvp.Key, 0);
                    }

                    participants[innerKvp.Key] += innerKvp.Value;
                }
            }

            counter = 0;
            Console.WriteLine("Individual standings:");
            foreach (var item in participants.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                counter++;
                Console.WriteLine($"{counter}. {item.Key} -> {item.Value}");
            }
        }
    }
}
