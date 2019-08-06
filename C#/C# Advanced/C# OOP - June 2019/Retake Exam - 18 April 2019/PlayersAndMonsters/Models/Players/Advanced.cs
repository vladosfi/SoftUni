using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Advanced : Player
    {
        private const int Initial_Points = 250;

        public Advanced(ICardRepository cardRepository, string username) 
            : base(cardRepository, username, Initial_Points)
        {
        }
    }
}
