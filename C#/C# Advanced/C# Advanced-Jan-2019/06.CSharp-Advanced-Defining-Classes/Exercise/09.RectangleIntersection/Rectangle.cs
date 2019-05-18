namespace _09.RectangleIntersection
{
    public class Rectangle
    {
        public string Id { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public Rectangle(string id, double width, double height, double x, double y)
        {
            this.Id = id;
            this.Width = width;
            this.Height = height;
            this.X = x;
            this.Y = y;
        }

        public static bool IntersectionCheck(Rectangle r1, Rectangle r2)
        {

            if (r2.X + r2.Width >= r1.X && 
                r2.X <= r1.X + r1.Width && 
                r2.Y >= r1.Y - r1.Height && 
                r2.Y - r2.Height <= r1.Y)
            {
                return true;
            }

            return false;
        }
    }
}
