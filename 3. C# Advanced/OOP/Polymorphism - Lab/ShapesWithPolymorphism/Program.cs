using System;

namespace ShapesWithPolymorphism
{
    public class Program
    {
        static void Main(string[] args)
        {
            Shape shape = null;
            while (true)
            {
                Console.WriteLine($"Shape: ");
                string type = Console.ReadLine();

                Console.WriteLine($"Size: ");
                int size = int.Parse(Console.ReadLine());

                Console.WriteLine($"Row: ");
                int row = int.Parse(Console.ReadLine());

                Console.WriteLine($"Col: ");
                int col = int.Parse(Console.ReadLine());

                Console.WriteLine($"Color: ");
                ConsoleColor color = Enum.Parse<ConsoleColor>(Console.ReadLine(), true);

                if (type == "circle")
                {
                    shape = new Circle(color, new Position(row, col), size);
                }
                else if (type == "square")
                {
                    shape = new Square(color, new Position(row, col), size);
                }
                shape.ChangeColor();
                //shape.SetStartPosition();
                shape.Draw();
                shape.ResetColor();
            }
        }
    }
}
