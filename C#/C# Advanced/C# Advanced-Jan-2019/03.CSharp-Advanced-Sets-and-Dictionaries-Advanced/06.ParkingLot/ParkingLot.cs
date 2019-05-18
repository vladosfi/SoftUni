using System;
using System.Collections.Generic;

namespace _06.ParkingLot
{
    class ParkingLot
    {
        static void Main()
        {
            HashSet<string> parking = new HashSet<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                var tokens = input.Split(", ");
                string direction = tokens[0];
                string carNumber = tokens[1];

                if (direction == "IN")
                {
                    parking.Add(carNumber);
                }
                else if (direction == "OUT")
                {
                    parking.Remove(carNumber);
                }
            }

            if (parking.Count > 0)
            {
                foreach (var carNumber in parking)
                {
                    Console.WriteLine(carNumber);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            
        }
    }
}
