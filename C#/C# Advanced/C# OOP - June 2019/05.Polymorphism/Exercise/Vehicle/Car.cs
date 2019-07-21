namespace Polymorphism
{
    public class Car : Vehicle
    {
        private const double airConditionConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumptionLitersPerKm)
            : base(fuelQuantity, fuelConsumptionLitersPerKm + airConditionConsumption)
        {
        }

        
    }
}
