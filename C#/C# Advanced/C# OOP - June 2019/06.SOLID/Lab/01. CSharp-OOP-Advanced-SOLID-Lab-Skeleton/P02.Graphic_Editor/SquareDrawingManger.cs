using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    class SquareDrawingManger : DrawingManager
    {
        public void Draw(IShape shape)
        {
            Console.WriteLine("Draw square");
        }
    }
}
