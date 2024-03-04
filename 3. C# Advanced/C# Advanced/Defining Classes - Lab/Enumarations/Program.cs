using System;
using System.Threading;

namespace Enumarations
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Direction directionEnum = Direction.Right;
            //if(directionEnum == Direction.Right)
            //{
            //    Console.WriteLine(directionEnum);
            //}


            int row = 0;
            int col = 0;
            Direction direction = Direction.Down;
            while (true)
            {
                Console.SetCursorPosition(col, row);
                Console.WriteLine("@");


                if(direction == Direction.Down)
                {
                    row++;
                }
                else if(direction == Direction.Right)
                {
                    col++;
                }
                else if (direction == Direction.Left)
                {
                    col--;
                }
                else if (direction == Direction.Up)
                {
                    row--;
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();

                    if(key.Key == ConsoleKey.RightArrow)
                    {
                        direction = Direction.Right;
                    }
                    else if(key.Key == ConsoleKey.LeftArrow)
                    {
                        direction = Direction.Left;
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        direction = Direction.Down;
                    }
                    else if (key.Key == ConsoleKey.UpArrow)
                    {
                        direction = Direction.Up;
                    }


                }
                Thread.Sleep(1);

                Console.Clear();
            }
        }
    }
}
