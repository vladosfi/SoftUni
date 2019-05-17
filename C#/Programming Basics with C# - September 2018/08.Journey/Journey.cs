using System;

namespace _08.Journey
{
    class Journey
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string seaseon = Console.ReadLine();
            string destination = "";
            string typeOfRest = "";

            if (budget > 0 && budget <= 100)
            {
                destination = "Bulgaria";

                if (seaseon == "summer")
                {
                    budget = budget * 0.30;
                    typeOfRest = "Camp";
                }
                else
                {
                    budget = budget * 0.70;
                    typeOfRest = "Hotel";
                }
            }
            else if (budget > 100 && budget <= 1000)
            {
                destination = "Balkans";

                if (seaseon == "summer")
                {
                    budget = budget * 0.40;
                    typeOfRest = "Camp";
                }
                else
                {
                    typeOfRest = "Hotel";
                    budget = budget * 0.80;
                }
            }
            else if (budget > 1000)
            {
                destination = "Europe";
                typeOfRest = "Hotel";
                budget = budget * 0.90;
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{typeOfRest} - {budget:f02}");
        }
    }
}
