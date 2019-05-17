using System;

namespace _06.ThreeBrothers
{
    class ThreeBrothers
    {
        static void Main(string[] args)
        {
            double brotherA = double.Parse(Console.ReadLine());
            double brotherB = double.Parse(Console.ReadLine());
            double brotherC = double.Parse(Console.ReadLine());
            double fatherD = double.Parse(Console.ReadLine());
            double cleanTime = 1/(1/brotherA + 1/brotherB + 1/brotherC);
            double timeLeft, insufficiencyTime;
            cleanTime = cleanTime + (cleanTime * 0.15);
            
            Console.WriteLine($"Cleaning time: {cleanTime:F02}");

            if (fatherD > cleanTime)
            {
                timeLeft = Math.Floor(fatherD - cleanTime);
                Console.WriteLine($"Yes, there is a surprise - time left -> {timeLeft} hours.");
            }
            else
            {
                insufficiencyTime = Math.Ceiling(cleanTime - fatherD);
                Console.WriteLine($"No, there isn't a surprise - shortage of time -> {insufficiencyTime} hours.");
                
            }

        }
    }
}
