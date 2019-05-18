using System;
using System.Collections.Generic;
using System.Text;

namespace _12.Google
{
    public class Pokemon
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public Pokemon(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append($"{this.Name} {this.Type}");

            return result.ToString();
        }
    }
}
