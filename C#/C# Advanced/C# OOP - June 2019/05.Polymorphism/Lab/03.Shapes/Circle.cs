﻿using System;

namespace Shapes
{
    public class Circle : Shape
    {
        private readonly double radius;
        
        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * this.radius * this.radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * this.radius;
        }

        public override string Draw()
        {
            return base.Draw() + "Circle";
        }
    }
}
