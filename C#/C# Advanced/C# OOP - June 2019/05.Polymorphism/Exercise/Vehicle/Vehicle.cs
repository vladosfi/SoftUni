namespace Polymorphism
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumptionLitersPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionLitersPerKm = fuelConsumptionLitersPerKm;
        }

        public double FuelQuantity { get; private set; }
        public double FuelConsumptionLitersPerKm { get; private  set; }

        public string Drive(double distance)
        {
            bool canDrive = distance * (this.FuelConsumptionLitersPerKm) < this.FuelQuantity;

            if (canDrive)
            {
                this.FuelQuantity -= distance * (this.FuelConsumptionLitersPerKm);
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
