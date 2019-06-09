using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Cargo
    {
        private string type;
        private int weight;

        public string Type { get => type; private set => type = value; }
        public int Weight { get => weight; private set => weight = value; }

        public Cargo(int weight, string type)
        {
            this.weight = weight;
            this.type = type;
        }        
    }
}
