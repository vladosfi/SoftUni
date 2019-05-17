using System;

namespace _04.Moving
{
    class Moving
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double lenght = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            string command = "";
            int boxCount = 0;
            double freeSpace = width * height * lenght;


            while (command != "Done" && freeSpace >= 0)
            {
                command = Console.ReadLine();

                if (int.TryParse(command, out boxCount))
                {
                    freeSpace = freeSpace - boxCount;
                }
            }

            if (command == "Done")
            {
                Console.WriteLine($"{freeSpace} Cubic meters left.");
            }
            else
            {
                Console.WriteLine($"No more free space! You need {Math.Abs(freeSpace)} Cubic meters more.");
            }

        }
    }
}
