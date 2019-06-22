    using System;
    using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
    public class Gladiator
    {
        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            this.Name = name;
            this.Stat = stat;
            this.Weapon = weapon;
        }

        public string Name { get; set; }

        public Stat Stat { get; set; }

        public Weapon Weapon { get; set; }

        public int GetTotalPower()
        {
            return this.GetStatPower() + this.GetWeaponPower();
        }

        public int GetWeaponPower()
        {
            return this.Weapon.Size + this.Weapon.Sharpness + this.Weapon.Solidity;
        }

        public int GetStatPower()
        {
            return this.Stat.Agility + 
                this.Stat.Flexibility + 
                this.Stat.Intelligence + 
                this.Stat.Skills +
                this.Stat.Strength;
        }

        public override string ToString()
        {
            StringBuilder gladiatorInfo = new StringBuilder();
            gladiatorInfo.AppendLine($"[{this.Name}] - [{this.GetTotalPower()}]");
            gladiatorInfo.AppendLine($"  Weapon Power: [{this.GetWeaponPower()}]");
            gladiatorInfo.AppendLine($"  Stat Power: [{this.GetStatPower()}]");
            return gladiatorInfo.ToString().TrimEnd();
        }
    }
}
