using System;

namespace _07.OnTimeForTheExam
{
    class OnTimeForTheExam
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMin = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMin = int.Parse(Console.ReadLine());

            int examTime = examHour * 60 + examMin;
            int arrivalTime = arrivalHour * 60 + arrivalMin;


            if (arrivalTime > examTime)
            {
                if (arrivalTime - examTime < 60)
                {
                    Console.WriteLine("Late");
                    Console.WriteLine($"{arrivalTime - examTime} minutes after the start");
                }
                else
                {
                    arrivalTime = arrivalTime - examTime;

                    while (arrivalTime >= 60)
                    {
                        arrivalMin = (arrivalTime % 60);
                        arrivalTime = arrivalTime / 60;
                    }

                    Console.WriteLine("Late");
                    Console.WriteLine($"{arrivalTime}:{arrivalMin:#00} hours after the start");
                }
            }
            else if (arrivalTime == examTime)
            {
                Console.WriteLine("On time");
            }
            else if (arrivalTime < examTime) 
            {
                if (examTime - arrivalTime <= 30)
                {
                    Console.WriteLine("On time");
                    Console.WriteLine($"{(examTime - arrivalTime)} minutes before the start");
                }
                else if (examTime - arrivalTime > 30 && examTime - arrivalTime < 60)
                {
                    Console.WriteLine("Early");
                    Console.WriteLine($"{(examTime - arrivalTime)} minutes before the start");
                }
                else if (examTime - arrivalTime >= 30)
                {
                    arrivalTime = examTime - arrivalTime;
                    arrivalMin = arrivalMin + (arrivalTime % 60);

                    while (arrivalTime >= 60)
                    {
                        arrivalMin = (arrivalTime % 60);
                        arrivalTime = arrivalTime / 60;
                    }

                    Console.WriteLine("Early");
                    Console.WriteLine($"{arrivalTime}:{arrivalMin:#00} hours before the start");
                }
            }




        }
    }
}
