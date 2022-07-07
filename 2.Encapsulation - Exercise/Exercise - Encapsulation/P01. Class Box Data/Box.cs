using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return length;
            }
            private set
            {
                if (value < 0)
                {
                   throw new ArgumentOutOfRangeException($"{nameof(Length)} cannot be zero or negative.");
                }
                length = value;
            }
        }
        public double Width
        {
            get
            {
                return width;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(Width)} cannot be zero or negative.");
                }
                width = value;
            }
        }
        public double Height
        {
            get
            {
                return height;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(Height)} cannot be zero or negative.");
                }
                height = value;
            }
        }

        private double SurfaceArea()
        {
            return (2 * Length * width) + (2 * Length * Height) + (2 * Width * Height);
        }
        private double LateralSurfaceArea()
        {
            return (2 * Length * Height) + (2 * Width * Height);
        }
        private double Volume()
        {
            return Length * Width * Height;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {SurfaceArea():F2}");
            sb.AppendLine($"Lateral Surface Area - {LateralSurfaceArea():F2}");
            sb.AppendLine($"Volume - {Volume():F2}");
            return sb.ToString().TrimEnd();
        }
    }
}
