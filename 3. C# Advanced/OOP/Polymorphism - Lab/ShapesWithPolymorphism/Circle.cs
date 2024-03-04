using System;
using System.Collections.Generic;
using System.Text;

namespace ShapesWithPolymorphism
{
    public class Circle : Shape
    {
        public Circle(ConsoleColor color, Position position, int size) 
            : base(color, position, size)
        {
        }

        public override void Draw()
        {
            double radius = Size;
            double thickness = 0.4;
            double rIn = radius - thickness;
            double rOut = radius + thickness;
            char symbol = '*';
            Console.WriteLine();
            int moveCursor = 0;
            for (double y = radius; y >= -radius; --y)
            {
                Console.SetCursorPosition(Position.Left, Position.Top + moveCursor);
                moveCursor++;
                for (double x = -radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;
                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        Console.Write(symbol.ToString());
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
