using System;

namespace _07.TheatrePromotion
{
    class TheatrePromotion
    {
        static void Main()
        {
            string day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            if (age >= 0 && age <= 122 && (day == "Weekday" || day == "Weekend" || day == "Holiday"))
            {
                if (day == "Weekday")
                {
                    if (age >= 0 && age <= 18 || age > 64 && age <= 122)
                    {
                        Console.WriteLine("12$");
                    }
                    else if (age > 18 && age <= 64)
                    {
                        Console.WriteLine("18$");
                    }
                }
                else if (day == "Weekend")
                {
                    if (age >= 0 && age <= 18 || age > 64 && age <= 122)
                    {
                        Console.WriteLine("15$");
                    }
                    else if (age > 18 && age <= 64)
                    {
                        Console.WriteLine("20$");
                    }
                }
                else if (day == "Holiday")
                {
                    if (age >= 0 && age <= 18)
                    {
                        Console.WriteLine("5$");
                    }
                    else if (age > 18 && age <= 64)
                    {
                        Console.WriteLine("12$");
                    }
                    else if (age > 64 && age <= 122)
                    {
                        Console.WriteLine("10$");
                    }
                }
            }
            else
            {
                Console.WriteLine("Error!");
            }

        }
    }
}
