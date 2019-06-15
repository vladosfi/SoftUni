using System;
using System.Collections.Generic;

namespace _04.CitiesByContinent
{
    class CitiesByContinent
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var continents = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string continet = tokens[0];
                string country = tokens[1];
                string city = tokens[2];

                if (!continents.ContainsKey(continet))
                {
                    continents.Add(continet, new Dictionary<string, List<string>>());
                }

                if (!continents[continet].ContainsKey(country))
                {
                    continents[continet].Add(country, new List<string>());
                }

                continents[continet][country].Add(city);
            }

            foreach (var kvp in continents)
            {
                Console.WriteLine($"{kvp.Key}:");

                foreach (var innerKvp in kvp.Value)
                {
                    Console.WriteLine($"{innerKvp.Key} -> {string.Join(", ", innerKvp.Value)}");
                }
            }
        }
    }
}
