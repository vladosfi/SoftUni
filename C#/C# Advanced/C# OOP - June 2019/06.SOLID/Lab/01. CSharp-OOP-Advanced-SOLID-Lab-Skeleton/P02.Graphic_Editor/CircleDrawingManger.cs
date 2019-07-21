using System;
namespace P02.Graphic_Editor
{
    class CircleDrawingManger : DrawingManager
    {
        public void Draw(IShape shape)
        {
            Console.WriteLine("Draw circle");
        }
    }
}
