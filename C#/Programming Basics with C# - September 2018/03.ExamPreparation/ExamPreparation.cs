using System;

namespace _03.ExamPreparation
{
    class ExamPreparation
    {
        static void Main(string[] args)
        {
            int unsatisfactoryValuations = int.Parse(Console.ReadLine());
            int unsatisfactoryCount = 0;
            string taskName = "";
            string lastTaskName = "";
            int problem = 0;
            int problemCount = 0;
            double averageRating = 0;

            while (unsatisfactoryCount < unsatisfactoryValuations)
            {
                lastTaskName = taskName;
                taskName = Console.ReadLine();

                if (taskName == "Enough")
                {
                    break;
                }
                else
                {
                    problem = int.Parse(Console.ReadLine());
                    problemCount++;
                    averageRating = averageRating + problem;
                }                

                if (problem <= 4)
                {
                    unsatisfactoryCount++;
                }
            }

            if (unsatisfactoryCount < unsatisfactoryValuations)
            {
                Console.WriteLine($"Average score: {averageRating / problemCount:f02}");
                Console.WriteLine($"Number of problems: {problemCount}");
                Console.WriteLine($"Last problem: {lastTaskName}");
            }
            else
            {
                Console.WriteLine($"You need a break, {unsatisfactoryCount} poor grades.");
            }
            
        }
    }
}
