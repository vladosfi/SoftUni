using System;
using System.Collections.Generic;
using System.Linq;

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
                var input = Console.ReadLine().Split(" -> ");
                string color = input[0];
                List<string> clotes = input[1].Split(",").ToList();

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }

                foreach (var clote in clotes)
                {
                    if (!wardrobe[color].ContainsKey(clote))
                    {
                        wardrobe[color][clote] = 1;
                    }
                    else
                    {
                        wardrobe[color][clote]++;
                    }
                }
            }

            string[] searchClote = Console.ReadLine().Split();

            string searchedColor = searchClote[0];
            string searchedDress = searchClote[1];

            foreach (var kvp in wardrobe)
            {
                Console.WriteLine($"{kvp.Key} clothes:");
                foreach (var innerKvp in kvp.Value)
                {
                    Console.Write($"* {innerKvp.Key} - {innerKvp.Value}");
                    if (searchedColor == kvp.Key && innerKvp.Key == searchedDress)
                    {
                        Console.Write(" (found!)");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
