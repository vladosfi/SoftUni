using System;

namespace _03.GraduationPt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string studentName = Console.ReadLine();
            int classNumber = 1;
            int broken = 0;
            double rating = 0;
            double avgRating = 0;

            while (classNumber <= 12 && broken != 2)
            {
                rating = double.Parse(Console.ReadLine());
                if (rating >= 4)
                {
                    classNumber++;
                    avgRating = avgRating + rating;
                }
                else
                {
                    broken++;
                }
            }

            if (broken != 2)
            {
                Console.WriteLine($"{studentName} graduated. Average grade: {avgRating/(classNumber-1):f02}");
            }
            else
            {
                Console.WriteLine($"{studentName} has been excluded at {classNumber} grade");
            }
            
        }
    }
}
