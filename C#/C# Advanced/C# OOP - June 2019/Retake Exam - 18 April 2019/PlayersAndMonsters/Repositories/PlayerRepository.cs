using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<IPlayer> playerRepo;

        public PlayerRepository()
        {
            this.playerRepo = new List<IPlayer>();
        }

        public int Count => this.playerRepo.Count;

        public IReadOnlyCollection<IPlayer> Players => this.playerRepo.AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            if (this.playerRepo.Any(p => p.Username == player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }

            this.playerRepo.Add(player);
        }

        public IPlayer Find(string username)
        {
            return this.playerRepo.FirstOrDefault(p => p.Username == username);
        }
        
        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            return this.playerRepo.Remove(player);
        }
    }
}
