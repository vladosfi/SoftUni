using System;
using System.Collections.Generic;
using System.Text;

namespace _02.PointInRectangle
{
    public class Rectangle
    {

        public Rectangle(Point topLeft, Point bottomLeft)
        {
            this.TopLeft = topLeft;
            this.BottomRight = bottomLeft;
        }

        public Point TopLeft { get; private set; }

        public Point BottomRight{ get; private set; }


        public bool Contains(Point point)
        {
            bool inHorizontal = 
                point.X <= this.BottomRight.X &&
                point.X >= TopLeft.X;

            bool inVertical = 
                point.Y <= this.BottomRight.Y &&
                point.Y >= TopLeft.Y;

            bool inRectangle = inHorizontal && inVertical;

            return inRectangle;
        }
    }
}
