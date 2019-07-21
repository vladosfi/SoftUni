using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class DrawingManager : DrawingManager
    {
        public void Draw(IShape shape)
        {
            throw new NotImplementedException();
        }

        protected abstract void DrawFigure(IShape shape);
    }
}
