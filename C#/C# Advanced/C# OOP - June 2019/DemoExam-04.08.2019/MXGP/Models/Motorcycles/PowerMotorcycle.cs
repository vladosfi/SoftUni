using System;
using MXGP.Utilities.Messages;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        public PowerMotorcycle(string model, int horsePower)
            : base(model, horsePower, 450)
        {

            if (this.HorsePower < 70 || this.HorsePower > 100 )
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, this.HorsePower));
            }
        }
    }
}
