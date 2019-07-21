namespace Polymorphism
{
    public class Bus : Vehicle
    {
        private const double airConditionConsumption = 1.4;
        
        public Bus(double fuelQuantity, double fuelConsumptionLitersPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionLitersPerKm + airConditionConsumption, tankCapacity)
        {
        }

        public string DriveEmpty(double distance)
        {
            double fuelConsumptionForEmtyBus = this.FuelConsumptionLitersPerKm - airConditionConsumption;

            bool canDrive = distance * (fuelConsumptionForEmtyBus) < this.FuelQuantity;

            if (canDrive)
            {
                this.FuelQuantity -= distance * (fuelConsumptionForEmtyBus);
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }
    }
}
