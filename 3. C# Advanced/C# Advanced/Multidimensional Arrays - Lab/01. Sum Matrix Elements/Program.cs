using System;
using System.Linq;

namespace _01._Sum_Matrix_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int rows = matrixSizes[0];
            int cols = matrixSizes[1];
            int[,] matrix = new int[rows, cols];
            int sum = 0;
            for (int row = 0; row < rows; row++)
            {
                int[] numbersOnCurrentRow = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = numbersOnCurrentRow[col];
                    sum += matrix[row, col];
                }
            }
            //for (int row = 0; row < rows; row++)
            //{
            //    for (int col = 0; col < cols; col++)
            //    {
            //        Console.Write(matrix[row, col] + " ");
            //    }
            //    Console.WriteLine();
            //}
            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }
    }
}
