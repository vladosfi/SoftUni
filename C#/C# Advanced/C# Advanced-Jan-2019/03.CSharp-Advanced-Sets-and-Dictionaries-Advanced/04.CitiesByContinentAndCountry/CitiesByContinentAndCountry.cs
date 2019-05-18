using System;
using System.Collections.Generic;

namespace _04.CitiesByContinentAndCountry
{
    class CitiesByContinentAndCountry
    {
        static void Main()
        {
            var continents = new Dictionary<string, List<string>>();
            var countrys = new Dictionary<string, List<string>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!continents.ContainsKey(continent))
                {
                    continents[continent] = new List<string>();
                }

                if (!continents[continent].Contains(country))
                {
                    continents[continent].Add(country);
                }

                if (!countrys.ContainsKey(country))
                {
                    countrys[country] = new List<string>();
                }

                if (!countrys[country].Contains(city))
                {
                    countrys[country].Add(city);
                }
            }

            foreach (var continentsKvp in continents)
            {
                Console.WriteLine($"{continentsKvp.Key}:");

                foreach (var country in continentsKvp.Value)
                {
                    Console.WriteLine($"  {country} -> {string.Join(", ", countrys[country])}");
                }
            }
        }
    }
}
