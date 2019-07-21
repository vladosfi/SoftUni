namespace Polymorphism
{
    public class Truck : Vehicle
    {
        private const double airConditionConsumption = 1.6;
        private const double lostFuel = 0.05;
        public Truck(double fuelQuantity, double fuelConsumptionLitersPerKm)
            : base(fuelQuantity, fuelConsumptionLitersPerKm + airConditionConsumption)
        {
        }

        
        public override void Refuel(double liters)
        {
            base.Refuel(liters - (liters * lostFuel));
        }
    }
}
