using System;

namespace _07.SpeedRacing
{
    public class Car
    {
        //model, fuel amount, fuel consumption for 1 kilometer and traveled distance

        public Car(string model, double fuelAmount, double fuelConsumptionFor1km)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionFor1km = fuelConsumptionFor1km;
            this.DistanceTraveled = 0;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionFor1km { get; set; }
        public double DistanceTraveled { get; set; }

        public void Drive(int amountOfKm)
        {
            bool carCanMove = FuelAmount - (amountOfKm * FuelConsumptionFor1km) >= 0;

            if (carCanMove)
            {
                this.FuelAmount -= (amountOfKm * FuelConsumptionFor1km);
                this.DistanceTraveled += amountOfKm;
            }
            else
            {
                throw new ArgumentException("Insufficient fuel for the drive");
            }
        }
    }
}
