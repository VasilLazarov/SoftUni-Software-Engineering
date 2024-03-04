using System;
using System.Collections.Generic;
using System.Text;

namespace ShapesWithoutPolymorphism
{
    public class Circle
    {
        public Circle(ConsoleColor color, Position position, int size)
        {
            Color = color;
            Position = position;
            Size = size;
        }

        public ConsoleColor Color { get; set; }
        public Position Position { get; set; }

        public int Size { get; set; }
        public void ChangeColor(ConsoleColor color)
        {
            //Console.BackgroundColor = color;
            Console.ForegroundColor = color;
        }
        public void SetStartPosition()
        {
            Console.SetCursorPosition(Position.Left, Position.Top);
        }
        public void ResetColor()
        {
            //Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Draw()
        {
            double radius = Size;
            double thickness = 0.4;
            double rIn = radius - thickness;
            double rOut = radius + thickness;
            char symbol = '*';
            Console.WriteLine();
            for (double y = radius; y >= -radius; --y)
            {
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
