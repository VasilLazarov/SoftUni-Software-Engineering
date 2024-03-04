using System;

namespace _07._NxN_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            PrintMatrix(num);
        }

        static void PrintMatrix(int num)
        {
            for (int i = 0; i < num; i++)
            {
                for (int v = 0; v < num; v++)
                {
                    Console.Write($"{num} ");
                }
                Console.WriteLine();
            }
        }
    }
}
