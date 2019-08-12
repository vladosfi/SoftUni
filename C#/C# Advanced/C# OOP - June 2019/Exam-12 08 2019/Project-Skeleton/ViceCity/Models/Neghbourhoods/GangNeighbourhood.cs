using System.Collections.Generic;
using System.Linq;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            int damage= 0;
            IGun gun = null;

            foreach (var item in mainPlayer.GunRepository.Models)
            {
                gun = item;
                break;
            }

            

            foreach (var civilPlayer in civilPlayers.Where(p=>p.IsAlive))
            {
                while (civilPlayer.IsAlive && gun.CanFire)
                {
                    civilPlayer.TakeLifePoints(gun.Fire());
                    
                }
            }



            foreach (var civilPlayer in civilPlayers)
            {
                if (civilPlayer == null || mainPlayer.IsAlive == false)
                {
                    break;
                }

                gun = null;

                foreach (var item in civilPlayer.GunRepository.Models)
                {
                    gun = item;
                    break;
                }

                while (mainPlayer.IsAlive && gun.CanFire)
                {
                    mainPlayer.TakeLifePoints(gun.Fire());
                }

                //IPlayer civilPlayer = civilPlayers.Where(p => p.IsAlive == true).FirstOrDefault();


            }
        }
    }
}
