using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    class Wardrobe
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");
                string color = input[0];
                string[] typeOfClothing = input[1].Split(",");

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }
                
                foreach (var clothing in typeOfClothing)
                {
                    if (!wardrobe[color].ContainsKey(clothing))
                    {
                        wardrobe[color].Add(clothing, 0);
                    }

                    wardrobe[color][clothing]++;
                }
            }

            string[] searchClothing = Console.ReadLine().Split();
            string searchColor = searchClothing[0];
            string searchType = searchClothing[1];

            foreach (var kvp in wardrobe)
            {
                Console.WriteLine($"{kvp.Key} clothes:");

                foreach (var innerKvp in kvp.Value)
                {
                    if (searchColor == kvp.Key && searchType == innerKvp.Key)
                    {
                        Console.WriteLine($"* {innerKvp.Key} - {innerKvp.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {innerKvp.Key} - {innerKvp.Value}");
                    }
                }
            }

        }
    }
}
