using System;
using MXGP.Utilities.Messages;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        public SpeedMotorcycle(string model, int horsePower) 
            : base(model, horsePower, 125)
        {
            if (this.HorsePower < 50 || this.HorsePower > 69)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, this.HorsePower));
            }
        }
    }
}
