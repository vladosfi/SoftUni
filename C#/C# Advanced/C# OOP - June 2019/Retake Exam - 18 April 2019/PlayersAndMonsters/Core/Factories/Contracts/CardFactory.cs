namespace PlayersAndMonsters.Core.Factories.Contracts
{
    using PlayersAndMonsters.Models.Cards;
    using PlayersAndMonsters.Models.Cards.Contracts;

    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            ICard card = null;

            if (type == "Trap")
            {
                card = new TrapCard(name);
            }
            else if (type == "Magic")
            {
                card = new MagicCard(name);
            }

            return card;
        }
    }
}
