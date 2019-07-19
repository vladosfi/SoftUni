namespace Polymorphism
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumptionLitersPerKm)
            :base(fuelQuantity, fuelConsumptionLitersPerKm)
        {
            this.FuelQuantity = fuelQuantity; 
            this.FuelConsumptionLitersPerKm = fuelConsumptionLitersPerKm;
            this.ExtraFuelConsumption = 1.6;
        }


        public override void Refuel(double liters)
        {
            double lostFuel = 0.05;
            this.FuelQuantity += liters - (liters * lostFuel);
        }
    }
}
