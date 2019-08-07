using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Linq;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            if (attackPlayer is Beginner)
            {
                IncreacePoints(attackPlayer);
            }
            if (enemyPlayer is Beginner)
            {
                IncreacePoints(enemyPlayer);
            }
            
            

            attackPlayer.Health += attackPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);
            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);

            int attackerDamage = attackPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);
            int enemyDamage = enemyPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);

            while (true)
            {

                enemyPlayer.TakeDamage(attackerDamage);

                if (enemyPlayer.Health == 0)
                {
                    break;
                }

                attackPlayer.TakeDamage(enemyDamage);

                if (attackPlayer.Health == 0)
                {
                    break;
                }
            }
        }

        private static void IncreacePoints(IPlayer player)
        {
            player.Health += 40;

            foreach (var card in player.CardRepository.Cards)
            {
                card.DamagePoints += 30;
            }
        }
    }
}
