using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _01.VaporWinterSale
{
    class Game
    {
        private string name;
        private decimal price;
        private string dlc;

        public Game(string name, decimal price, string dlc)
        {
            this.name = name;
            this.price = price;
            this.dlc = dlc;
        }

        public string Name => this.name;
        public decimal Price => this.price;
        public string DLC => this.dlc;

        public void AddDLC(string dlc)
        {
            this.dlc = dlc;
        }

        public void IncreasePriceBy20Percent()
        {
            this.price += this.price * 0.2m;
        }

        public void DecreasePrice(decimal percent)
        {
            this.price -= this.price * percent;
        }
    }
    class VaporWinterSale
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            List<Game> games = new List<Game>();

            string[] input = Console.ReadLine().Split(", ");


            foreach (var game in input)
            {
                string[] tokens;
                if (game.Contains("-"))
                {
                    tokens = game.Split("-");
                    string name = tokens[0];
                    decimal price = decimal.Parse(tokens[1]);

                    if (games.FindIndex(x => x.Name == name) == -1)
                    {
                        Game newGame = new Game(
                            name,
                            price,
                            string.Empty
                        );

                        games.Add(newGame);
                    }

                }
                else if (game.Contains(":"))
                {
                    tokens = game.Split(":");
                    string name = tokens[0];
                    string dlc = tokens[1];

                    int indexOfGame = games.FindIndex(x => x.Name == name);
                    if (indexOfGame != -1)
                    {
                        games[indexOfGame].AddDLC(dlc);
                        games[indexOfGame].IncreasePriceBy20Percent();
                    }
                }

            }


            var gamesWithDLC = games.Where(x => x.DLC != string.Empty);

            foreach (var game in gamesWithDLC)
            {
                game.DecreasePrice(0.5m);
            }

            var gamesWithoutDLC = games.Where(x => x.DLC == string.Empty);

            foreach (var game in gamesWithoutDLC)
            {
                game.DecreasePrice(0.2m);
            }

            foreach (var item in gamesWithDLC)
            {

            }

            foreach (var game in gamesWithDLC.OrderBy(x => x.Price))
            {
                Console.WriteLine($"{game.Name} - {game.DLC} - {game.Price:f02}");
            }

            foreach (var game in gamesWithoutDLC.OrderByDescending(x => x.Price))
            {
                Console.WriteLine($"{game.Name} - {game.Price:f02}");
            }
        }
    }
}
