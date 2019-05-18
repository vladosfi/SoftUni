using System;
using System.Collections.Generic;
using System.Text;

namespace _10.CarSalesman
{
    public class Engine
    {
        public string Model { get; set; }
        public int Power { get; set; }
        public string Displacement { get; set; }
        public string Efficiency { get; set; }

        public Engine()
        {
        }

        public Engine(string model, int power)
            :this(model, power, "n/a", "n/a")
        {
        }
        
        public Engine(string model, int power, string displacement, string efficiency)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }
    }
}
