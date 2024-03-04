using System;

namespace _11._Multiplication_Table_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int startingMultiplier = int.Parse(Console.ReadLine());
            if (startingMultiplier > 10)
            {
                Console.WriteLine($"{input} X {startingMultiplier} = {input * startingMultiplier}");
            }
            for (int i = startingMultiplier; i <= 10; i++)
            {
                Console.WriteLine($"{input} X {i} = {input * i}");
            }
        }
    }
}
