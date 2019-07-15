using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary)
        {
            ParseCorps(corps);
        }

        public Corps Corps { get; private set; }

        private void ParseCorps(string corpStr)
        {
            Corps corp;

            bool parsed = Enum.TryParse<Corps>(corpStr, out corp);

            if (!parsed)
            {
                throw new InvalidCorpsException();
            }

            this.Corps = corp;
        }

        public override string ToString()
        {
            return base.ToString() +
                Environment.NewLine +
                $"Corps: {this.Corps}";
        }
    }
}
