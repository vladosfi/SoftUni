using System;
using System.Text;
using ClassBoxData.Exceptions;

namespace ClassBoxData.Models
{
    public class Box
    {
        private double lenght;

        private double width;

        private double height;

        public Box(double lenght, double width, double height)
        {
            this.Lenght = lenght;
            this.Width = width;
            this.Height = height;
        }

        public double Lenght
        {
            get
            {
                return this.lenght;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.LenghtZeroOrNegativeException);
                }

                this.lenght = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.WidthZeroOrNegativeException);
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.HeightZeroOrNegativeException);
                }

                this.height = value;
            }
        }


        public double SurfaceArea()
        {
            double surfaceArea = this.LateralSurfaceArea() + (2 * this.Lenght * this.Width);

            return surfaceArea;
        }

        public double LateralSurfaceArea()
        {
            double lateralSurfaceArea = (2 * this.Lenght * this.Height) + (2 * this.Width * this.Height);

            return lateralSurfaceArea;
        }

        public double Volume()
        {
            double volume = this.Lenght * this.Width * this.Height;

            return volume;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Surface Area - {this.SurfaceArea():f2}");
            result.AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():f2}");
            result.AppendLine($"Volume - {this.Volume():f2}");

            return result.ToString().TrimEnd(); 
        }
    }
}
