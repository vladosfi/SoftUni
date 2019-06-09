using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public int Count { get => this.cars.Count;}

        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new List<Car>();
        }

        public string AddCar(Car car)
        {
            if (cars.Any(c=>c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (capacity == cars.Count)
            {
                return "Parking is full!";
            }

            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].RegistrationNumber == registrationNumber)
                {
                    cars.RemoveAt(i);
                    return $"Successfully removed {registrationNumber}";
                }
            }

            return "Car with that registration number, doesn't exist!";
        }

        public Car GetCar(string registrationNumber)
        {
            Car carToReturn = cars.Where(c => c.RegistrationNumber == registrationNumber).FirstOrDefault();

            return carToReturn;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var number in registrationNumbers)
            {
                for (int i = 0; i < cars.Count; i++)
                {
                    if (cars[i].RegistrationNumber == number)
                    {
                        cars.RemoveAt(i);
                    }
                }
            }            
        }
    }
}
