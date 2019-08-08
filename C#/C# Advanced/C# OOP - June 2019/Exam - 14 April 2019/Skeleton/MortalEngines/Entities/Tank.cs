namespace MortalEngines.Entities.Models
{    
    using System.Text;
    using MortalEngines.Entities.Contracts;

    public class Tank : BaseMachine, ITank
    {
        private const double InitialHealthPoints = 100;
        private const double InitialAttackPoints = 40;
        private const double InitialDefensePoints = 30;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints - InitialAttackPoints,
                defensePoints + InitialDefensePoints,
                InitialHealthPoints)
        {
            this.DefenseMode = true;
        }

        public bool DefenseMode { get; private set; }
        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == true)
            {
                this.DefenseMode = false;
                base.AttackPoints += InitialAttackPoints;
                base.DefensePoints -= InitialDefensePoints;
            }
            else
            {
                this.DefenseMode = true;
                base.AttackPoints -= InitialAttackPoints;
                base.DefensePoints += InitialDefensePoints;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.Append(" *Defense: ");
            sb.AppendLine(DefenseMode == true ? "ON" : "OFF");
            return sb.ToString().TrimEnd();
        }
    }
}