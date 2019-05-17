using System;

namespace _02.Graduation
{
    class Graduation
    {
        static void Main(string[] args)
        {
            string studentName = Console.ReadLine();
            double rating;
            double avgRating = 0;
            int classNumber = 1;


            while (classNumber <= 12)
            {
                rating = double.Parse(Console.ReadLine());
                if (rating >= 4)
                {
                    avgRating = avgRating + rating;
                    classNumber++;
                }
            }

            Console.WriteLine($"{studentName} graduated. Average grade: {avgRating / 12:f02}");
        }
    }
}
