using System;
using System.Collections.Generic;
using System.Text;

namespace _10.CarSalesman
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }

        public Car(string model, Engine engine)
            : this(model, engine, "n/a", "n/a")
        {
        }

        public Car(string model, Engine engine, string weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{Model}:");
            result.AppendLine($"  {Engine.Model}:");
            result.AppendLine($"    Power: {Engine.Power}");
            result.AppendLine($"    Displacement: {Engine.Displacement}");
            result.AppendLine($"    Efficiency: {Engine.Efficiency}");
            result.AppendLine($"  Weight: {Weight}");
            result.Append($"  Color: {Color}");

            return result.ToString();
        }
    }
}
