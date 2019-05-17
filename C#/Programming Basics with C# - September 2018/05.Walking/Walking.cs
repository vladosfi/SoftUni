using System;

namespace _05.Walking
{
    class Walking
    {
        static void Main(string[] args)
        {
            int stepsToHome = 0;
            string inputVal = "";
            int stepPassed = 0;
            bool lastStepsToHome = false;

            while ((stepPassed < 10000) && lastStepsToHome == false)
            {
                if (inputVal == "Going home")
                {
                    lastStepsToHome = true;
                }

                inputVal = Console.ReadLine();
                if (int.TryParse(inputVal, out stepsToHome))
                {
                    stepPassed = stepPassed + stepsToHome;
                }                
            }

            if (stepPassed >= 10000)
            {
                Console.WriteLine("Goal reached! Good job!");
            }
            else
            {
                Console.WriteLine($"{10000 - stepPassed} more steps to reach goal.");
            }
        }
    }
}
