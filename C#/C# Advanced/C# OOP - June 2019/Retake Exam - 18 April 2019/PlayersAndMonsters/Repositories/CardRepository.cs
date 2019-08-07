using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly List<ICard> cardsRepo;

        public CardRepository()
        {
            this.cardsRepo = new List<ICard>();
        }

        public int Count => this.cardsRepo.Count;

        public IReadOnlyCollection<ICard> Cards => this.cardsRepo.AsReadOnly();

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null");
            }

            if (this.cardsRepo.Any(p => p.Name == card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            this.cardsRepo.Add(card);
        }

        public ICard Find(string name)
        {
            return this.cardsRepo.FirstOrDefault(p => p.Name == name);
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null");
            }

            return this.cardsRepo.Remove(card);
        }
    }
}
