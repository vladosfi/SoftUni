using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Ranking
    {
        static void Main()
        {
            Dictionary<string, string> contestCredentials = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> students = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine == "end of contests")
                {
                    break;
                }

                var tokens = inputLine.Split(":");
                string contest = tokens[0];
                string pass = tokens[1];

                if (!contestCredentials.ContainsKey(contest))
                {
                    contestCredentials[contest] = pass;
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of submissions")
                {
                    break;
                }

                var tokens = input.Split("=>");
                string contest = tokens[0];
                string pass = tokens[1];

                if (contestCredentials.ContainsKey(contest) && contestCredentials[contest] == pass)
                {
                    string student = tokens[2];
                    int points = int.Parse(tokens[3]);

                    if (!students.ContainsKey(student))
                    {
                        students[student] = new Dictionary<string, int>();
                    }

                    if (!students[student].ContainsKey(contest))
                    {
                        students[student][contest] = 0;
                    }

                    if (students[student][contest] < points)
                    {
                        students[student][contest] = points;
                    }
                }
            }


            var bestCandidate = students
                .OrderByDescending(x => x.Value.Values.Sum())
                .FirstOrDefault();

            Console.WriteLine($"Best candidate is {bestCandidate.Key} " +
                $"with total {bestCandidate.Value.Values.Sum()} points.");

            Console.WriteLine($"Ranking:");
            foreach (var candidate in students.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{candidate.Key}");

                foreach (var kvp in candidate.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {kvp.Key} -> {kvp.Value}");
                }
            }
        }
    }
}
