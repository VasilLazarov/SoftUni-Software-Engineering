using System;
using System.Collections.Generic;
using System.Text;

namespace ShapesWithPolymorphism
{
    public abstract class Shape
    {
        public Shape(ConsoleColor color, Position position, int size)
        {
            Color = color;
            Position = position;
            Size = size;
        }

        public ConsoleColor Color { get; set; }
        public Position Position { get; set; }

        public int Size { get; set; }

        public abstract void Draw();
        public void ChangeColor()
        {
            //Console.BackgroundColor = color;
            Console.ForegroundColor = Color;
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
    }
}
