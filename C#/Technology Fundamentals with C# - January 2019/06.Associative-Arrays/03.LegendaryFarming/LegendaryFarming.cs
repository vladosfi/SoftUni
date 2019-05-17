using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LegendaryFarming
{
    class LegendaryFarming
    {
        static void Main()
        {
            Dictionary<string, int> legendary = new Dictionary<string, int>();
            legendary.Add("shards", 0);
            legendary.Add("fragments", 0);
            legendary.Add("motes", 0);
            SortedDictionary<string, int> junks = new SortedDictionary<string, int>();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split();

                for (int i = 0; i < tokens.Length; i = i + 2)
                {
                    int quantity = int.Parse(tokens[i]);
                    string material = tokens[i+1].ToLower();

                    switch (material)
                    {
                        case "shards":
                            legendary[material] += quantity;

                            if (IsGoalReached(legendary, material))
                            {
                                Console.WriteLine($"Shadowmourne obtained!");
                                legendary[material] -= 250;
                                PrintMaterials(legendary, junks);
                                return;
                            }

                            break;
                        case "fragments":
                            legendary[material] += quantity;

                            if (IsGoalReached(legendary, material))
                            {
                                Console.WriteLine($"Valanyr obtained!");
                                legendary[material] -= 250;
                                PrintMaterials(legendary, junks);
                                return;
                            }

                            break;
                        case "motes":
                            legendary[material] += quantity;

                            if (IsGoalReached(legendary, material))
                            {
                                Console.WriteLine($"Dragonwrath obtained!");
                                legendary[material] -= 250;
                                PrintMaterials(legendary, junks);
                                return;
                            }

                            break;
                        default:
                            if (!junks.ContainsKey(material))
                            {
                                junks.Add(material, 0);
                            }
                            junks[material] += quantity;
                            break;
                    }
                }

            }
        }

        private static void PrintMaterials(Dictionary<string, int> legendary, SortedDictionary<string, int> junks)
        {
            foreach (var kvp in legendary
                .OrderByDescending(x =>x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            foreach (var kvp in junks)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }

        private static bool IsGoalReached(Dictionary<string, int> legendary, string material)
        {
            if (legendary[material] >= 250)
            {
                return true;
            }
            return false;
        }
    }
}
