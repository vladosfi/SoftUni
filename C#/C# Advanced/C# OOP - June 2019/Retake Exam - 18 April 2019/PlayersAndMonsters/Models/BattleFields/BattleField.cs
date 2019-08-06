using PlayersAndMonsters.Models.BattleFields.Contracts;
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

            if (attackPlayer.GetType().Name == "Beginner")
            {
                IncreacePoints(attackPlayer);
            }
            if (enemyPlayer.GetType().Name == "Beginner")
            {
                IncreacePoints(enemyPlayer);
            }

            attackPlayer.Health += attackPlayer.CardRepository.Cards.Select(c => c.HealthPoints).Sum();
            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Select(c => c.HealthPoints).Sum();

            int attackerDamage = attackPlayer.CardRepository.Cards.Select(c => c.DamagePoints).Sum();
            int enemyDamage = enemyPlayer.CardRepository.Cards.Select(c => c.DamagePoints).Sum();

            bool OddFight = false; 

            while (!attackPlayer.IsDead && !enemyPlayer.IsDead)
            {
                OddFight = !OddFight;

                if (OddFight)
                {
                    if (enemyPlayer.Health - attackerDamage < 0)
                    {
                        enemyPlayer.Health = 0;
                    }
                    else
                    {
                        enemyPlayer.Health -= attackerDamage;
                    }
                }
                else
                {
                    if (attackPlayer.Health - enemyDamage < 0)
                    {
                        attackPlayer.Health = 0;
                    }
                    else
                    {
                        attackPlayer.Health -= enemyDamage;
                    }
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
