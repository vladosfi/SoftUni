using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Tires
    {
        private double tirePressure;
        private int tireAge;

        public double TirePressure { get => tirePressure; private set => tirePressure = value; }
        public int TireAge { get => tireAge; private set => tireAge = value; }

        public Tires(double tirePressure,
            int tireAge)
        {
            this.TirePressure = tirePressure;
            this.TireAge = tireAge;
        }
    }
}
