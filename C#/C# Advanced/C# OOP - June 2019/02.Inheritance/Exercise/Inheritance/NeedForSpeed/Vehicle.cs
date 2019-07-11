namespace NeedForSpeed
{
    public class Vehicle
    {

        private const double DEFAULT_FUEL_CONSUMPTION = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public int HorsePower { get; set; }

        public double Fuel { get; set; }

        public virtual double FuelConsumption => DEFAULT_FUEL_CONSUMPTION;

        public virtual void Drive(double kilometers)
        {
            double fuelNeeded = kilometers * this.FuelConsumption;

            if (this.Fuel >= fuelNeeded)
            {
                this.Fuel -= kilometers * this.FuelConsumption;
            }
        }

    }
}
