using System;

namespace _07.Scholarship
{
    class Scholarship
    {
        static void Main()
        {
            decimal earnings = decimal.Parse(Console.ReadLine());
            decimal averageSuccess = decimal.Parse(Console.ReadLine());
            decimal minWorkSalary = decimal.Parse(Console.ReadLine());
            decimal scholarshipForResults = 0;
            decimal scholarshipForSocial = 0;

            if (averageSuccess > 4.5m)
            {
                scholarshipForSocial = minWorkSalary * 0.35m;

                if (averageSuccess >= 5.5m)
                {
                    scholarshipForResults = averageSuccess * 25;
                }
                
                if ((scholarshipForSocial >= scholarshipForResults) && earnings <= minWorkSalary)
                {
                    Console.WriteLine($"You get a Social scholarship {Math.Floor(scholarshipForSocial)} BGN");
                }
                else if(scholarshipForResults > 0)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(scholarshipForResults)} BGN");
                }
                else
                {
                    Console.WriteLine("You cannot get a scholarship!");
                }
            }
            else
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
        }
    }
}
