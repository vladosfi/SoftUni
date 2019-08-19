using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Utilities.Messages;
using System;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private readonly IBag bag;

        protected Astronaut(string name, double oxygen)
        {
            this.Name= name;
            this.Oxygen = oxygen;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }

                this.name = value;
            }
        }

        public double Oxygen
        {
            get
            {
                return this.oxygen;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }

                this.oxygen = value;
            }
        }

        public bool CanBreath => this.oxygen > 0;

        public IBag Bag => this.Bag;

        public virtual void Breath()
        {
            if (this.oxygen - 10 < 0)
            {
                this.oxygen = 0;
            }
            else
            {
                this.oxygen -= 10;
            }
        }
    }
}
