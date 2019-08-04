using System;
using MXGP.Utilities.Messages;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private const int PowerMotorcycleCubicCentimeters = 450;
        private int horsePower;

        public PowerMotorcycle(string model, int horsePower)
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
                if (value < 70 || value  > 100)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            }
        }  

    }
}
