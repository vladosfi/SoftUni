using System;

namespace _05.GameInfo
{
    class GameInfo
    {
        static void Main()
        {
            string teamName = Console.ReadLine();
            int playedMatches = int.Parse(Console.ReadLine());
            int meetingTime = 0;
            double totalMeetingTime = 0;
            int extraTime = 0;
            int penalty = 0;

            for (int i = 0; i < playedMatches; i++)
            {
                meetingTime = int.Parse(Console.ReadLine());
                totalMeetingTime = totalMeetingTime + meetingTime;

                if (meetingTime > 90 && meetingTime <= 120)
                {
                    extraTime++;
                }
                if (meetingTime > 120)
                {
                    penalty++;
                }
            }

            Console.WriteLine($"{teamName} has played {totalMeetingTime} minutes. Average minutes per game: {totalMeetingTime / playedMatches:f02}");
            Console.WriteLine($"Games with penalties: {penalty}");
            Console.WriteLine($"Games with additional time: {extraTime}");
        }
    }
}
