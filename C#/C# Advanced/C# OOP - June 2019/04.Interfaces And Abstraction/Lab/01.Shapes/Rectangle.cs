using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public string Draw()
        {
            var sb = new StringBuilder();

            sb.Append(DrawLine(this.width, '*', '*'));

            for (int i = 1; i < this.height - 1; ++i)
            {
                sb.Append(DrawLine(this.width, '*', ' '));
            }
            sb.Append(DrawLine(this.width, '*', '*'));

            return sb.ToString();
        }

        private string DrawLine(int width, char end, char mid)
        {
            var sb = new StringBuilder();

            sb.Append(end.ToString());

            for (int i = 1; i < width - 1; ++i)

                sb.Append(mid.ToString());

            sb.AppendLine(end.ToString());


            return sb.ToString();
        }
    }
}
