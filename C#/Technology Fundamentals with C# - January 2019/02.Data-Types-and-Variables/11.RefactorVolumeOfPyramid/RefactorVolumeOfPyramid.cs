using System;

namespace _11.RefactorVolumeOfPyramid
{
    class RefactorVolumeOfPyramid
    {
        static void Main()
        {
            double lenght, width, height = 0;
            double volume = 0;
            Console.Write("Length: ");
            lenght = double.Parse(Console.ReadLine());
            Console.Write("Width: ");
            width = double.Parse(Console.ReadLine());
            Console.Write("Height: ");
            height = double.Parse(Console.ReadLine());
            volume = (lenght * width * height) / 3.0;
            Console.Write($"Pyramid Volume: {volume:f2}");

        }
    }
}
