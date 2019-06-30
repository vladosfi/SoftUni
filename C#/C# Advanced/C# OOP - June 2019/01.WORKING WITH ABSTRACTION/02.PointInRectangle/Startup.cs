using System;
using System.Linq;

namespace _02.PointInRectangle
{
    class Startup
    {
        static void Main(string[] args)
        {
            int[] rectanglePoints = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int topLeftX = rectanglePoints[0];
            int topLeftY = rectanglePoints[1];
            int bottomRightX = rectanglePoints[2];
            int bottomRightY = rectanglePoints[3];
            
            Point topLeft = new Point(topLeftX, topLeftY);
            Point bottomRight = new Point(bottomRightX, bottomRightY);
            Rectangle rectangle = new Rectangle(topLeft, bottomRight);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] pointCoordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int pointX = pointCoordinates[0];
                int pointY = pointCoordinates[1];
                Point point = new Point(pointX, pointY);
                Console.WriteLine(rectangle.Contains(point));
            }

        }
    }
}
