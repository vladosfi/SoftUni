namespace MXGP.Models.Motorcycles
{
    using System;
    using MXGP.Utilities.Messages;

    public class SpeedMotorcycle : Motorcycle
    {
        private const int MinHorsePower = 50;
        private const int MaxHorsePower = 69;
        private const int DefaultCubicCentimeters = 125;

        private int horsePower;

        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, DefaultCubicCentimeters)
        {
        }

        public override int HorsePower
        {
            get => this.horsePower;

            protected set
            {
                if (value < MinHorsePower || value > MaxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            }
        }
    }
}
