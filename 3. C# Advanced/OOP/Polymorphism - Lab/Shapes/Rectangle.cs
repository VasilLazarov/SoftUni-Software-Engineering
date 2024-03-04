using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {


		private double height;
        private double width;

		public Rectangle(double height, double width)
		{
			Height = height;
			Width = width;
		}

		public double Height
		{
			get { return height; }
			private set { height = value; }
		}

		public double Width
		{
			get { return width; }
			private set { width = value; }
		}

		public override double CalculateArea()
		{
            double area = Height * Width;
            return area;
        }

		public override double CalculatePerimeter()
		{
            double area = (2 * Height) + (2 * Width);
            return area;
        }
        public override string Draw()
        {
            return $"Drawing {GetType().Name}";
        }
    }
}
