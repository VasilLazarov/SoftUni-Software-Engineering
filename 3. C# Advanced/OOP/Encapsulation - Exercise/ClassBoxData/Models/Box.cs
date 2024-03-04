using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData.Models
{
    public class Box
    {
        private const string PropertyValueExceptionMessage = "{0} cannot be zero or negative.";

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length 
        {
            get => length;
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentException(string.Format(PropertyValueExceptionMessage, nameof(Length)));
                }
                this.length = value;
            }
        }
        public double Width
        {
            get => width;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(PropertyValueExceptionMessage, nameof(Width)));
                }
                this.width = value;
            }
        }
        public double Height
        {
            get => height;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(PropertyValueExceptionMessage, nameof(Height)));
                }
                this.height = value;
            }
        }

        public double SurfaceArea()
        {
            return (2*Length*Width) + LateralSurfaceArea();
        }
        public double LateralSurfaceArea()
        {
            return (2 * Length * Height) + (2 * Width * Height);
        }
        public double Volume()
        {
            return Length * Width * Height;
        }

        public override string ToString()
        {
            return $"Surface Area - {SurfaceArea():f2}{Environment.NewLine}Lateral Surface Area - {LateralSurfaceArea():f2}{Environment.NewLine}Volume - {Volume():f2}";
        }
    }
}
