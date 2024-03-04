using System;

namespace _6._Building
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int floor = int.Parse(Console.ReadLine());
            int roomsPerFLoor = int.Parse(Console.ReadLine());

            for(int i = floor; i >= 1; i--)
            {
                for(int j = 0; j < roomsPerFLoor; j++)
                {
                    if(i == floor)
                    {
                        Console.Write($"L{i}{j} ");
                    }
                    else if(i % 2 == 0)
                    {
                        Console.Write($"O{i}{j} ");
                    }
                    else if(i % 2 != 0)
                    {
                        Console.Write($"A{i}{j} ");
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}
