using System;

namespace _09.Moving
{
    class Moving
    {
        static void Main()
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int apartmentCubic = width * lenght * height;
            int boxCount = 0;
            int boxCubic = 0;
            string command = "";

            do
            {
                command = Console.ReadLine();
                if (int.TryParse(command, out boxCount))
                {
                    boxCubic = boxCubic + boxCount;
                }

            } while (apartmentCubic >= boxCubic && command != "Done");


            if (boxCubic <= apartmentCubic && command == "Done")
            {
                Console.WriteLine($"{apartmentCubic - boxCubic} Cubic meters left.");
            }
            else if(command != "Done")
            {
                Console.WriteLine($"No more free space! You need {boxCubic - apartmentCubic} Cubic meters more.");
            }
        }
    }
}
