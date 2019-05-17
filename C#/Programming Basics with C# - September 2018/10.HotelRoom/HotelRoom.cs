using System;

namespace _10.HotelRoom
{
    class HotelRoom
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int daysOfStay = int.Parse(Console.ReadLine());
            double studioPrice = 0;
            double apartmentPrice = 0;

            if (month == "May" || month == "October")
            {
                studioPrice = daysOfStay * 50;
                apartmentPrice = daysOfStay * 65;

                if (daysOfStay > 7 && daysOfStay <= 14)
                {
                    studioPrice = studioPrice - (studioPrice * 0.05);
                }
                else if (daysOfStay > 14)
                {
                    studioPrice = studioPrice - (studioPrice * 0.30);
                    apartmentPrice = apartmentPrice - (apartmentPrice * 0.10);
                }
            }
            else if (month == "June" || month == "September")
            {
                studioPrice = daysOfStay * 75.20;
                apartmentPrice = daysOfStay * 68.70;

                if (daysOfStay > 14)
                {
                    studioPrice = studioPrice - (studioPrice * 0.20);
                    apartmentPrice = apartmentPrice - (apartmentPrice * 0.10);
                }
            }
            else if (month == "July" || month == "August")
            {
                studioPrice = daysOfStay * 76;
                apartmentPrice = daysOfStay * 77;

                if (daysOfStay > 14)
                {
                    apartmentPrice = apartmentPrice - (apartmentPrice * 0.10);
                }
                
            }

            Console.WriteLine($"Apartment: {apartmentPrice:f02} lv.");
            Console.WriteLine($"Studio: {studioPrice:f02} lv.");
        }
    }
}
