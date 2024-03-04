using System;
using System.Linq;

namespace _03._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfSquareMatrix = int.Parse(Console.ReadLine());

            int[,] matrix = new int[sizeOfSquareMatrix, sizeOfSquareMatrix];
            for (int row = 0; row < sizeOfSquareMatrix; row++)
            {
                int[] numbersForCurrentRow = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < sizeOfSquareMatrix; col++)
                {
                    matrix[row, col] = numbersForCurrentRow[col];
                }
            }
            int sum = 0;
            for (int row = 0; row < sizeOfSquareMatrix; row++)
            {
                sum += matrix[row, row];
            }
            Console.WriteLine(sum);
            //int sum2 = 0; - for second diagonal
            //for (int row = 0; row < sizeOfSquareMatrix; row++)
            //{
            //    sum2 += matrix[row, sizeOfSquareMatrix - row -1];
            //}
            //Console.WriteLine(sum2);
        }
    }
}
