using System;
using System.Text;

namespace SoftUniParking
{
    public class Car : IComparable<Car>
    {
        private string make;
        private string model;
        private int horsePower;
        private string registrationNumber;

        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            this.make = make;
            this.model = model;
            this.horsePower = horsePower;
            this.registrationNumber = registrationNumber;
        }

        public string Make => this.make;
        public string Model => this.model;
        public int HorsePower => this.horsePower;
        public string RegistrationNumber => this.registrationNumber;

        public int CompareTo(Car other)
        {
            int resultNames = this.registrationNumber.CompareTo(other.registrationNumber);
            return resultNames;
        }

        public override string ToString()
        {
            return $"Make: {this.make}" + Environment.NewLine +
             $"Model: {this.model}" + Environment.NewLine +
             $"HorsePower: {this.horsePower}" + Environment.NewLine +
             $"RegistrationNumber: {this.registrationNumber}";
        }
    }
}
