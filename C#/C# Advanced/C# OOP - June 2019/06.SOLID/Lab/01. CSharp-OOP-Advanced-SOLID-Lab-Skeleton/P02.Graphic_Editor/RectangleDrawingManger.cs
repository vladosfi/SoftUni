using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    class RectangleDrawingManger : DrawingManager
    {
        public void Draw(IShape shape)
        {
            Console.WriteLine("Draw rectangle");
        }
    }
}
