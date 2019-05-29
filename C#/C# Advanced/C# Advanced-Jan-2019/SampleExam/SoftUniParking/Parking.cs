using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    class Parking
    {
        private Car[] cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new Car[this.capacity];
        }


    }
}
