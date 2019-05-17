using System;

namespace _03.PointInRectangle
{
    class PointInRectangle
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double px = double.Parse(Console.ReadLine());
            double py = double.Parse(Console.ReadLine());


            if (x1 < x2 && y1 < y2)
            {
                if ((px >= x1 && px <= x2) && (py >= y1 && py <= y2))
                {
                    Console.WriteLine("Inside");
                }
                else
                {
                    Console.WriteLine("Outside");
                }
            }


        }
    }
}
