using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private Cargo cargo;
        private Tires[] tires;
        private Engine engine;

        public string Model { get => model; private set => model = value; }
        public Cargo Cargo { get => cargo; private set => cargo = value; }
        public Tires[] Tires { get => tires; private set => tires = value; }
        public Engine Engine { get => engine; private set => engine = value; }

        public Car(
            string model, 
            int engineSpeed, 
            int enginePower, 
            int cargoWeight,
            string cargoType, 
            double tire1Pressure ,
            int tire1Age,
            double tire2Pressure,
            int tire2Age,
            double tire3Pressure,
            int tire3Age, 
            double tire4Pressure,
            int tire4Age)
        {
            this.Model = model;
            this.cargo = new Cargo(cargoWeight, cargoType);
            this.engine = new Engine(engineSpeed, enginePower);
            this.tires = new Tires[4];

            tires[0] = new Tires(tire1Pressure, tire1Age);
            tires[1] = new Tires(tire2Pressure, tire2Age);
            tires[2] = new Tires(tire3Pressure, tire3Age);
            tires[3] = new Tires(tire4Pressure, tire4Age);
        }

        
    }
}
