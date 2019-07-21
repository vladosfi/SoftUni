namespace Polymorphism
{
    public class Truck : Vehicle
    {
        private const double airConditionConsumption = 1.6;
        private const double lostFuel = 0.05;

        public Truck(double fuelQuantity, double fuelConsumptionLitersPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionLitersPerKm + airConditionConsumption, tankCapacity)
        {
        }


        public override void Refuel(double liters)
        {
            base.Refuel(liters);
            this.FuelQuantity -= (liters * lostFuel);
        }
    }
}
