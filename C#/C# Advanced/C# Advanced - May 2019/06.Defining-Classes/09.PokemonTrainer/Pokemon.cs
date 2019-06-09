using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Pokemon
    {
        private string name;
        private string element;
        private int health;

        public int Health { get => health; set => health = value; }
        public string Element { get => element; private set => element = value; }
        public string Name { get => name; private set => name = value; }

        public Pokemon(string name, string element, int health)
        {
            this.name = name;
            this.element = element;
            this.health = health;
        }
    }
}
