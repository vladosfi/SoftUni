using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.PracticeSessions
{
    class PracticeSessions
    {
        static void Main()
        {
            var sessions = new Dictionary<string, List<string>>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command.ToLower() == "end")
                {
                    break;
                }

                string[] tokens = command.Split("->");
                command = tokens[0];

                if (command == "Add")
                {
                    string road = tokens[1];
                    string racer = tokens[2];

                    if (!sessions.ContainsKey(road))
                    {
                        sessions.Add(road, new List<string>());
                    }

                    sessions[road].Add(racer);
                }
                else if (command == "Move")
                {
                    string currentRoad = tokens[1];
                    string racer = tokens[2];
                    string nextRoad = tokens[3];

                    if (sessions[currentRoad].Contains(racer))
                    {
                        sessions[currentRoad].Remove(racer);
                        sessions[nextRoad].Add(racer);
                    }
                }
                else if (command == "Close")
                {
                    string road = tokens[1];

                    if (sessions.ContainsKey(road))
                    {
                        sessions.Remove(road);
                    }
                }
            }

            if (sessions.Any())
            {
                Console.WriteLine("Practice sessions:");
                foreach (var session in sessions.OrderByDescending(x => x.Value.Count()).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{session.Key}");

                    foreach (var racer in session.Value)
                    {
                        Console.WriteLine($"++{racer}");
                    }
                }
            }

        }
    }
}
