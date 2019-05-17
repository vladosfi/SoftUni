using System;

namespace _08.TrainTheTrainers
{
    class TrainTheTrainers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string presentatioName;
            double rating = 0;
            double avgPresRating = 0;
            double totalAvgRating = 0;
            int presentationCounter = 0;

            while ((presentatioName = Console.ReadLine()) != "Finish")
            {
                avgPresRating = 0;
                rating = 0;

                for (int i = 0; i < n; i++)
                {
                    rating = rating + double.Parse(Console.ReadLine());
                }
                avgPresRating = rating / n;
                totalAvgRating = totalAvgRating + avgPresRating;
                presentationCounter++;
                Console.WriteLine($"{presentatioName} - {avgPresRating:F02}.");
            }
            totalAvgRating = totalAvgRating / presentationCounter;
            Console.WriteLine($"Student's final assessment is {totalAvgRating:F02}.");
        }
    }
}
