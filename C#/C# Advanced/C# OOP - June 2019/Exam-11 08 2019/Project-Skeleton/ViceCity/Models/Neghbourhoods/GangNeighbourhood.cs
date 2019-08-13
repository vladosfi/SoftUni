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
           foreach (var gun in mainPlayer.GunRepository.Models)
            {                
                foreach (var civilPlayer in civilPlayers.Where(p => p.IsAlive))
                {
                    while (civilPlayer.IsAlive && gun.CanFire)
                    {
                        civilPlayer.TakeLifePoints(gun.Fire());
                    }
                }
            }
           
            foreach (var civilPlayer in civilPlayers.Where(p => p.IsAlive))
            {
                foreach (var gun in civilPlayer.GunRepository.Models)
                {
                    while (mainPlayer.IsAlive && gun.CanFire)
                    {
                        mainPlayer.TakeLifePoints(gun.Fire());
                    }
                }
            }
        }
    }
}
