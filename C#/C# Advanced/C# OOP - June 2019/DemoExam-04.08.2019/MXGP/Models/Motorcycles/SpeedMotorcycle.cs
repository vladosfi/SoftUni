using System;
using MXGP.Utilities.Messages;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private const int PowerMotorcycleCubicCentimeters = 125;
        private int horsePower;

        public SpeedMotorcycle(string model, int horsePower) 
            : base(model, horsePower, PowerMotorcycleCubicCentimeters)
        {
        }

        public override int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            protected set
            {
                if (value < 50 || value > 69)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            }
        }
    }
}
