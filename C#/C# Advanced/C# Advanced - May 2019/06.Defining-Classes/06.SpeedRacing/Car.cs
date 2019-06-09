using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public double FuelAmount { get => fuelAmount; private set => fuelAmount = value; }
        public double TravelledDistance { get => travelledDistance; private set => travelledDistance = value; }

        public Car(double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.travelledDistance = 0;
            this.fuelAmount = fuelAmount;
            this.fuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }

        public void Drive(double amountOfKm)
        {
            bool canMove = this.fuelAmount - this.fuelConsumptionPerKilometer * amountOfKm >= 0;

            if (!canMove)
            {
                throw new ArgumentException("Insufficient fuel for the drive");
            }

            this.FuelAmount -= this.fuelConsumptionPerKilometer * amountOfKm;
            travelledDistance += amountOfKm;
        }
    }
}
