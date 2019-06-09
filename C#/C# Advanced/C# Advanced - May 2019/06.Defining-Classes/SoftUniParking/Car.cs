using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        private string make;
        private string model;
        private int horsePower;
        private string registrationNumber;

        public string Make { get => make; set => make = value; }
        public string Model { get => model; set => model = value; }
        public int HorsePower { get => horsePower; set => horsePower = value; }
        public string RegistrationNumber { get => registrationNumber; set => registrationNumber = value; }

        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            this.make = make;
            this.model = model;
            this.horsePower = horsePower;
            this.registrationNumber = registrationNumber;
        }


        public override string ToString()
        {
            StringBuilder carInfo = new StringBuilder();
            carInfo.AppendLine($"Make: {this.make}");
            carInfo.AppendLine($"Model: {this.model}");
            carInfo.AppendLine($"HorsePower: {this.horsePower}");
            carInfo.Append($"RegistrationNumber: {this.registrationNumber}");

            return carInfo.ToString();
        }
    }
}
