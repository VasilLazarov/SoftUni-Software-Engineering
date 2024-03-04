using System;

namespace _7._Moving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int capacity = width * height * length;
            string input = Console.ReadLine();
            int num = 0;
            while (input != "Done")
            {
                num = int.Parse(input);
                if(num <= capacity)
                {
                    capacity -= num;
                }
                else
                {
                    Console.WriteLine($"No more free space! You need {num - capacity} Cubic meters more.");
                    return;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"{capacity} Cubic meters left.");
        }
    }
}
