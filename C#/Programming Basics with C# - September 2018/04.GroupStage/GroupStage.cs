using System;

namespace _04.GroupStage
{
    class GroupStage
    {
        static void Main()
        {
            string teamName = Console.ReadLine();
            int playedMatches = int.Parse(Console.ReadLine());
            int pushinGoals = 0;
            int gotGoals = 0;
            int totalPushinGoals = 0;
            int totalGotGoals = 0;
            int points = 0;

            for (int i = 0; i < playedMatches; i++)
            {
                pushinGoals = int.Parse(Console.ReadLine());
                gotGoals = int.Parse(Console.ReadLine());
                totalPushinGoals = totalPushinGoals + pushinGoals;
                totalGotGoals = totalGotGoals + gotGoals;

                if (pushinGoals > gotGoals)
                {
                    points = points + 3;
                }
                else if (pushinGoals == gotGoals)
                {
                    points++;
                }
            }


            if (totalPushinGoals >= totalGotGoals)
            {
                Console.WriteLine($"{teamName} has finished the group phase with {points} points.");
                Console.WriteLine($"Goal difference: {totalPushinGoals - totalGotGoals}.");
            }
            else
            {
                Console.WriteLine($"{teamName} has been eliminated from the group phase.");
                Console.WriteLine($"Goal difference: {totalPushinGoals - totalGotGoals}.");
            }

        }
    }
}
