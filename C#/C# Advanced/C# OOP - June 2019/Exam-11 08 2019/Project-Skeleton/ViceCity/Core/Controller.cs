using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private readonly GunRepository gunsRepo;
        private readonly List<IPlayer> civilPlayers;
        private IPlayer mainPlayer;

        public Controller()
        {
            this.gunsRepo = new GunRepository();
            this.civilPlayers = new List<IPlayer>();
            this.mainPlayer = new MainPlayer();
        }

        public IPlayer MainPlayer { get => mainPlayer; set => mainPlayer = value; }

        public string AddGun(string type, string name)
        {
            IGun gun = null;

            if (type == "Pistol")
            {
                gun = new Pistol(name);
            }
            else if (type == "Rifle")
            {
                gun = new Rifle(name);
            }
            else
            {
                return "Invalid gun type!";
            }

            this.gunsRepo.Add(gun);

            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {

            if (this.gunsRepo.Models.Count <= 0)
            {
                return "There are no guns in the queue!";
            }

            IGun firestGun = null;

            firestGun = this.gunsRepo.Models.FirstOrDefault();
            
            if (name.Contains("Vercetti"))
            {
                mainPlayer.GunRepository.Add(firestGun);
                this.gunsRepo.Remove(firestGun);
                return $"Successfully added {firestGun.Name} to the Main Player: Tommy Vercetti";
            }

            if (!this.civilPlayers.Any(p => p.Name == name))
            {
                return "Civil player with that name doesn't exists!";
            }

            IPlayer player = this.civilPlayers.FirstOrDefault(p => p.Name == name);
            player.GunRepository.Add(firestGun);

            this.gunsRepo.Remove(firestGun);

            return $"Successfully added {firestGun.Name} to the Civil Player: {name}";

        }

        public string AddPlayer(string name)
        {
            IPlayer player = new CivilPlayer(name);
            this.civilPlayers.Add(player);

            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            GangNeighbourhood gangNeighbourhood = new GangNeighbourhood();

            gangNeighbourhood.Action(this.mainPlayer, this.civilPlayers);



            if (this.mainPlayer.LifePoints == 100 && civilPlayers.All(p => p.LifePoints == 50))
            {
                return "Everything is okay!";
            }


            StringBuilder result = new StringBuilder();
            result.AppendLine("A fight happened:");
            result.AppendLine($"Tommy live points: {mainPlayer.LifePoints}!");
            result.AppendLine($"Tommy has killed: {this.civilPlayers.Where(p => p.IsAlive == false).Count()} players!");
            result.AppendLine($"Left Civil Players: { this.civilPlayers.Where(p => p.IsAlive == true).Count()}!");

            return result.ToString().TrimEnd();
        }
    }
}
