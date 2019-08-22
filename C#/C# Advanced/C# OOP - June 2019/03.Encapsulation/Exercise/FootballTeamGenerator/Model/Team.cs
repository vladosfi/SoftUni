using System;
using System.Collections.Generic;
using System.Linq;
using FootballTeamGenerator.Model;

namespace FootballTeamGenerator.Model
{
    public class Team
    {
        private readonly List<Player> players;
        private string name;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"A name should not be empty.");
                }

                this.name = value;
            }
        }

        public double Rating => this.CalculateRating();

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player players = this.players.FirstOrDefault(p => p.Name == playerName);

            if (players == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }
            else
            {
                this.players.Remove(players);
            }
        }


        private double CalculateRating()
        {
            double rating = 0;

            if (players.Count > 0)
            {
                rating = players.Average(p=>p.Stats);
            }

            return rating;
        }
    }
}
