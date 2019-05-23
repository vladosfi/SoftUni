using System;
using System.Collections.Generic;

namespace _06.ParkingLot
{
    class ParkingLot
    {
        static void Main()
        {
            HashSet<string> cars = new HashSet<string>();

            string input = Console.ReadLine();

            while (input.ToLower() != "end")
            {
                string[] tokens = input.Split(", ");
                string direction = tokens[0].ToLower();
                string carNumber = tokens[1];

                if (direction == "in")
                {
                    cars.Add(carNumber);
                }
                else if (direction == "out")
                {
                    cars.Remove(carNumber);
                }
                input = Console.ReadLine();
            }

            if (cars.Count > 0)
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
