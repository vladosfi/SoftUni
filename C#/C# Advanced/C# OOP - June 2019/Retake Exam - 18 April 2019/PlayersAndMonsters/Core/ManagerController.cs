namespace PlayersAndMonsters.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.Cards;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private IPlayerRepository playersRepo;
        private ICardRepository cardsRepo;

        public ManagerController()
        {
            playersRepo = new PlayerRepository();
            cardsRepo = new CardRepository();
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = null;

            if (type == nameof(Beginner))
            {
                player = new Beginner(new CardRepository(), username);
            }
            else if (type == nameof(Advanced))
            {
                player = new Advanced(new CardRepository(), username);
            }

            playersRepo.Add(player);

            return $"Successfully added player of type {type} with username: {username}";
        }

        public string AddCard(string type, string name)
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

            cardsRepo.Add(card);

            return $"Successfully added card of type {type}Card with name: {name}";
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = playersRepo.Find(username);
            ICard card = cardsRepo.Find(cardName);

            player.CardRepository.Add(card);

            return $"Successfully added card: {cardName} to user: {username}";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attackPlayer = playersRepo.Find(attackUser);
            IPlayer enemyPlayer = playersRepo.Find(enemyUser);

            BattleField batle = new BattleField();
            batle.Fight(attackPlayer, enemyPlayer);

            return $"Attack user health {attackPlayer.Health} - Enemy user health {enemyPlayer.Health}";
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
