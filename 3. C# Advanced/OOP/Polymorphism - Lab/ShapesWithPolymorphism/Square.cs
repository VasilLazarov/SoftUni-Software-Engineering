using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ShapesWithPolymorphism
{
    public class Square : Shape
    {
        public Square(ConsoleColor color, Position position, int size)
            : base(color, position, size)
        {
        }

        public override void Draw()
        {
            //Console.WriteLine();
            int moveCursorForLastLine = 0;
            DrawLine(this.Size, '*', '*', 0);
            for (int i = 1; i < this.Size - 1; ++i)
            {
                DrawLine(this.Size, '*', ' ', i);
                moveCursorForLastLine = i;
            }
            moveCursorForLastLine++;
            DrawLine(this.Size, '*', '*', moveCursorForLastLine);
        }
        private void DrawLine(int width, char end, char mid, int moveCursor)
        {
            //bool firstSymbol = true;
            Console.SetCursorPosition(Position.Left, Position.Top + moveCursor);
            Console.Write(end);
            for (int i = 1; i < width - 1; ++i)
            {
                //if (firstSymbol)
                //{
                //    firstSymbol = false;
                //    Console.Write(end);
                //}
                Console.Write(mid);
            }
            Console.WriteLine(end);
        }
    }
}
