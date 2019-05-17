using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniExamResults
{
    class SoftUniExamResults
    {
        static void Main()
        {
            Dictionary<string, int> results = new Dictionary<string, int>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();


            while (true)
            {
                string[] tokens = Console.ReadLine().Split("-");

                if (tokens[0] == "exam finished")
                {
                    break;
                }

                string username = tokens[0];
                string language = tokens[1];

                if (language == "banned")
                {
                    if (results.ContainsKey(username))
                    {
                        results.Remove(username);
                    }

                    continue;
                }

                int points = int.Parse(tokens[2]);
                
                if (!results.ContainsKey(username))
                {
                    results.Add(username, 0);
                }

                if (results[username] < points)
                {
                    results[username] = points;
                }
                

                if (!submissions.ContainsKey(language))
                {
                    submissions.Add(language, 0);
                }
                submissions[language]++;
            }


            Console.WriteLine("Results:");
            foreach (var kvp in results.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var kvp in submissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
