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

            //TO DO CHECK IF ONLY ONE PLAER MUST BE CHECKED
            //•	If the player is a beginner, increase his health with 40 points and increase all damage points of all cards for the user with 30.
            if (attackPlayer.GetType().Name == "Beginner")
            {
                IncreacePoints(attackPlayer);
            }
            if (enemyPlayer.GetType().Name == "Beginner")
            {
                IncreacePoints(enemyPlayer);
            }


            //•	Before the fight, both players get bonus health points from their deck.
            attackPlayer.Health += attackPlayer.CardRepository.Cards.Select(c => c.HealthPoints).Sum();
            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Select(c => c.HealthPoints).Sum();

            //•	Attacker attacks first and after that the enemy attacks.If one of the players is dead you should stop the fight.
            int attackerDamage = attackPlayer.CardRepository.Cards.Select(c => c.DamagePoints).Sum();
            int enemyDamage = attackPlayer.CardRepository.Cards.Select(c => c.DamagePoints).Sum();

            bool OddFight = false; 

            while (!(enemyPlayer.IsDead && enemyPlayer.IsDead))
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
