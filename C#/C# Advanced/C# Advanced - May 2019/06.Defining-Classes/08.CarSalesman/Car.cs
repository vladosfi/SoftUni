using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public string Model { get => model; private set => model = value; }
        public Engine Engine { get => engine; private set => engine = value; }
        public int Weight { get => weight; set => weight = value; }
        public string Color { get => color; set => color = value; }

        public Car(string model, Engine engine, int weight, string color)
        {
            this.model = model;
            this.engine = engine;
            this.weight = weight;
            this.color = color;
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine, weight, "n/a")
        {
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine, -1, color)
        {
        }

        public Car(string model, Engine engine)
            : this(model, engine, -1)
        {
        }


        public override string ToString()
        {
            string weight = this.weight.ToString();
            string displacement = this.engine.Displacement.ToString();

            if (weight == "-1")
            {
                weight = "n/a";
            }

            if (displacement == "-1")
            {
                displacement = "n/a";
            }

            StringBuilder carInfo = new StringBuilder();
            carInfo.AppendLine($"{this.model}:");
            carInfo.AppendLine($"  {this.engine.Model}:");
            carInfo.AppendLine($"    Power: {this.engine.Power}");
            carInfo.AppendLine($"    Displacement: {displacement}");
            carInfo.AppendLine($"    Efficiency: {this.engine.Efficiency}");
            carInfo.AppendLine($"  Weight: {weight}");
            carInfo.Append($"  Color: {this.color}");
            

            return carInfo.ToString();
        }
    }
}
