using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {

        private double radius;

        public Circle(int radius)
        {
            Radius = radius;
        }

        public double Radius
        {
            get { return radius; }
            private set { radius = value; }
        }


        public override double CalculateArea()
        {
            double area = Math.PI * radius * radius;
            return area;
        }

        public override double CalculatePerimeter()
        {
            double area = 2 * Math.PI * radius;
            return area;
        }
        public override string Draw()
        {
            return $"Drawing {GetType().Name}";
        }
    }
}
