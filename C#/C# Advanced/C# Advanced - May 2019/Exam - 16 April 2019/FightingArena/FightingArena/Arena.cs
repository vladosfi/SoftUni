using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightingArena
{
    public class Arena
    {
        private List<Gladiator> gladiators;
        
        public Arena(string name)
        {
            this.Name = name;
            this.gladiators = new List<Gladiator>();
        }

        public string Name { get; set; }

        public int Count => this.gladiators.Count();

        public void Add(Gladiator gladiator)
        {
            this.gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            Gladiator gladiatorToRemove = gladiators.Where(g => g.Name == name).FirstOrDefault();

            if (gladiatorToRemove != null)
            {
                gladiators.Remove(gladiatorToRemove);
            }
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            Gladiator gladitorWithHighestStatPower = gladiators
                .OrderByDescending(g => g.GetStatPower())
                .FirstOrDefault();

            return gladitorWithHighestStatPower;
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            Gladiator gladitorWithHighestWeaponPower = gladiators
                .OrderByDescending(g => g.GetWeaponPower())
                .FirstOrDefault();

            return gladitorWithHighestWeaponPower;
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            Gladiator gladitorWithHighestTotalPower = gladiators
                .OrderByDescending(g => g.GetTotalPower())
                .FirstOrDefault();

            return gladitorWithHighestTotalPower;
        }

        public override string ToString()
        {
            StringBuilder arenaInfo = new StringBuilder();

            arenaInfo.AppendLine($"[{this.Name}] - [{this.Count}] gladiators are participating.");

            return arenaInfo.ToString().TrimEnd();
        }
    }
}
