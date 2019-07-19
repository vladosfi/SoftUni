namespace Polymorphism
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumptionLitersPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionLitersPerKm = fuelConsumptionLitersPerKm;
        }

        public double FuelQuantity { get; set; }
        public double FuelConsumptionLitersPerKm { get; set; }
        public double ExtraFuelConsumption { get; set; }

        public string Drive(double distance)
        {
            bool canDrive = distance * (this.FuelConsumptionLitersPerKm + this.ExtraFuelConsumption) < this.FuelQuantity;

            if (canDrive)
            {
                this.FuelQuantity -= distance * (this.FuelConsumptionLitersPerKm + this.ExtraFuelConsumption);
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public abstract void Refuel(double liters);
    }
}
