﻿namespace P01_RawData
{
    using System.Collections.Generic;

    public class Car
    {
        public Car(string model,
            int engineSpeed,
            int enginePower,
            int cargoWeight,
            string cargoType,
            params Tire[] tires
            )
        {
            this.Model = model;
            this.EngineSpeed = engineSpeed;
            this.EnginePower = enginePower;
            this.CargoWeight = cargoWeight;
            this.CargoType = cargoType;
            this.Tires = tires;
        }

        public Tire[] Tires { get; private set; }

        public string Model { get; private set; }

        public int EngineSpeed { get; private set; }

        public int EnginePower { get; private set; }

        public int CargoWeight { get; private set; }

        public string CargoType { get; private set; }
    }
}