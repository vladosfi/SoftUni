using System;
using System.Collections.Generic;
using System.Text;

namespace _12.Google
{
    public class Child
    {
        public string Name { get; set; }
        public string Birthday { get; set; }
        
        public Child(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append($"{this.Name} {this.Birthday}");

            return result.ToString();
        }
    }
}
