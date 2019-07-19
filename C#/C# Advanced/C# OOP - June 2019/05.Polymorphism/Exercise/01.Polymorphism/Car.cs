namespace Polymorphism
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumptionLitersPerKm)
            : base(fuelQuantity, fuelConsumptionLitersPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionLitersPerKm = fuelConsumptionLitersPerKm;
            this.ExtraFuelConsumption = 0.9;
        }
               
        public override void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }
    }
}
