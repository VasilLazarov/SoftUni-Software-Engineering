using System;

namespace ShapesWithoutPolymorphism
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine($"Shape: ");
                string shape = Console.ReadLine();

                Console.WriteLine($"Size: ");
                int size = int.Parse(Console.ReadLine());

                Console.WriteLine($"Row: ");
                int row = int.Parse(Console.ReadLine());

                Console.WriteLine($"Col: ");
                int col = int.Parse(Console.ReadLine());

                Console.WriteLine($"Color: ");
                ConsoleColor color = Enum.Parse<ConsoleColor>(Console.ReadLine(), true);


                if(shape == "square")
                {
                    Square square = new Square(color, new Position(row, col), size);

                    square.ChangeColor(color);
                    square.SetStartPosition();
                    square.Draw();
                    square.ResetColor();
                }
                else if (shape == "circle")
                {
                    Circle circle = new Circle(color, new Position(row, col), size);

                    circle.ChangeColor(color);
                    circle.SetStartPosition();
                    circle.Draw();
                    circle.ResetColor();
                }
            }
        }
    }
}
