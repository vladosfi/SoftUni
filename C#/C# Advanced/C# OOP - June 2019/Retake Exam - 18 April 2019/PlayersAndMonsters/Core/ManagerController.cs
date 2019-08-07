namespace PlayersAndMonsters.Core
{
    using System.Text;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Contracts;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;

    public class ManagerController : IManagerController
    {
        private PlayerRepository playersRepo;
        private CardRepository cardsRepo;
        private PlayerFactory playerFactory;
        private CardFactory cardFactory;

        public ManagerController()
        {
            playersRepo = new PlayerRepository();
            cardsRepo = new CardRepository();
            playerFactory = new PlayerFactory();
            cardFactory = new CardFactory();
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = playerFactory.CreatePlayer(type, username);
            playersRepo.Add(player);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            ICard card = cardFactory.CreateCard(type, name);
            cardsRepo.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = playersRepo.Find(username);
            ICard card = cardsRepo.Find(cardName);

            player.CardRepository.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attackPlayer = playersRepo.Find(attackUser);
            IPlayer enemyPlayer = playersRepo.Find(enemyUser);

            BattleField batle = new BattleField();
            batle.Fight(attackPlayer, enemyPlayer);

            return string.Format(ConstantMessages.FightInfo, attackPlayer.Health, enemyPlayer.Health);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();

            foreach (var player in playersRepo.Players)
            {
                report.AppendLine(string.Format(ConstantMessages.PlayerReportInfo, player.Username, player.Health, player.CardRepository.Cards.Count));
                foreach (var card in player.CardRepository.Cards)
                {
                    report.AppendLine(string.Format(ConstantMessages.CardReportInfo, card.Name, card.DamagePoints));
                }
                report.AppendLine(string.Format(ConstantMessages.DefaultReportSeparator));
            }
            return report.ToString().TrimEnd();
        }


    }
}
