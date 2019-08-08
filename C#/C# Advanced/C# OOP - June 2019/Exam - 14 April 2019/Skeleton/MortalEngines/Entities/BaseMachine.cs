namespace MortalEngines.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MortalEngines.Entities.Contracts;

    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;
        private readonly List<string> targets;

        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.targets = new List<string>();
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get => this.pilot;

            set
            {
                if (value is null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }

                this.pilot = value;
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; protected set; }

        public void Attack(IMachine target)
        {
            if (target is null)
            {
                throw new NullReferenceException("Target cannot be null");
            }
            
            double difference = Math.Abs(this.AttackPoints - target.DefensePoints);

            if (target.HealthPoints - difference <= 0)
            {
                target.HealthPoints = 0;
            }
            else
            {
                target.HealthPoints -= difference;
            }

            this.targets.Add(target.Name);
        }

        public override string ToString()
        {
            StringBuilder machineInfo = new StringBuilder();

            machineInfo.AppendLine($"- {this.name}");
            machineInfo.AppendLine($" *Type: {this.GetType().Name}");
            machineInfo.AppendLine($" *Health: {this.HealthPoints:f02}");
            machineInfo.AppendLine($" *Attack: {this.AttackPoints:f02}");
            machineInfo.AppendLine($" *Defense: {this.DefensePoints:f02}");

            if (this.targets.Count <= 0)
            {
                machineInfo.AppendLine(" *Targets: None");
            }
            else
            {
                machineInfo.AppendLine(" *Targets: " + string.Join(",", this.targets));
            }

            return machineInfo.ToString().TrimEnd();
        }
    }
}
