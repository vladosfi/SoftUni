using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.RectangleIntersection
{
    class StartUp
    {
        static void Main()
        {
            List<Rectangle> rectangles = new List<Rectangle>();

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = input[0];
            int m = input[1];

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string id = tokens[0];
                double width = double.Parse(tokens[1]);
                double height = double.Parse(tokens[2]);
                double x = double.Parse(tokens[3]);
                double y = double.Parse(tokens[4]);

                Rectangle rectangle = new Rectangle(id, width, height, x, y);
                rectangles.Add(rectangle);
            }


            for (int i = 0; i < m; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string firstId = tokens[0];
                string secondId = tokens[1];

                Rectangle firstRectangle = rectangles.Where(x => x.Id == firstId).FirstOrDefault();
                Rectangle secondRectangle = rectangles.Where(x => x.Id == secondId).FirstOrDefault();

                Console.WriteLine(Rectangle.IntersectionCheck(firstRectangle, secondRectangle).ToString().ToLower());
            }
        }
    }
}
