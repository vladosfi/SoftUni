using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _01.VaporWinterSale_Dic
{
    class VaporWinterSaleDic
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            Dictionary<string, decimal> gamesWithDLC = new Dictionary<string, decimal>();
            Dictionary<string, decimal> gamesWithoutDLC = new Dictionary<string, decimal>();
            
            string[] input = Console.ReadLine().Split(", ");

            foreach (var game in input)
            {
                string[] tokens;
                if (game.Contains("-"))
                {
                    tokens = game.Split("-");
                    string name = tokens[0];
                    decimal price = decimal.Parse(tokens[1]);

                    if (!gamesWithoutDLC.ContainsKey(name))
                    {
                        gamesWithoutDLC.Add(name, 0);
                    }

                    gamesWithoutDLC[name] = price;
                }
                else if (game.Contains(":"))
                {
                    tokens = game.Split(":");
                    string name = tokens[0];
                    string dlc = tokens[1];
                    
                    if (gamesWithoutDLC.ContainsKey(name))
                    {
                        if (!gamesWithDLC.ContainsKey(name))
                        {
                            gamesWithDLC.Add(name + " - " + dlc, 0);
                        }

                        gamesWithDLC[name + " - " + dlc] = gamesWithoutDLC[name] + (gamesWithoutDLC[name] * 0.2m);
                        gamesWithoutDLC.Remove(name);
                    }
                }

            }

            foreach (var game in gamesWithDLC.OrderBy(x => x.Value))
            {
                decimal price = game.Value - (game.Value * 0.5m);
                Console.WriteLine($"{game.Key} - {price:f02}");
            }

            foreach (var game in gamesWithoutDLC.OrderByDescending(x => x.Value))
            {
                decimal price = game.Value - (game.Value * 0.2m);
                Console.WriteLine($"{game.Key} - {price:f02}");
            }

            
        }
    }
}
