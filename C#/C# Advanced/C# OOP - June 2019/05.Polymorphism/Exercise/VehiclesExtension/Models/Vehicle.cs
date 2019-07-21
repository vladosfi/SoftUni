using System;
using VehiclesExtension.Exceptions;

namespace Polymorphism
{
    public abstract class Vehicle
    {
        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double fuelConsumptionLitersPerKm, double tankCapacity)
        {
            this.FuelConsumptionLitersPerKm = fuelConsumptionLitersPerKm;
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                if (value > TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public double FuelConsumptionLitersPerKm { get; private set; }

        public double TankCapacity { get; private set; }

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
            if (liters <= 0)
            {
                throw new InvalidOperationException(Messages.InvalidFuelMustBePositive);
            }
            else if (this.FuelQuantity + liters > this.TankCapacity)
            {
                throw new InvalidOperationException(string.Format(Messages.InvalidFuelQuantity, liters));
            }
            else if (this.FuelQuantity + liters <= this.TankCapacity)
            {
                this.FuelQuantity += liters;
            }

        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
