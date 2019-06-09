using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        private int speed;
        private int power;

        public int Speed { get => speed; private set => speed = value; }
        public int Power { get => power; private set => power = value; }

        public Engine(int speed, int power)
        {
            this.Speed = speed;
            this.power = power;
        }
    }
}
