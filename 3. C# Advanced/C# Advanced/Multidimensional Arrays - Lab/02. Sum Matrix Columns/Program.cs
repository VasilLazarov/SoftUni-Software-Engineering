using System;
using System.Linq;

namespace _02._Sum_Matrix_Columns
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
            for (int row = 0; row < rows; row++)
            {
                int[] numbersOnCurrentRow = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = numbersOnCurrentRow[col];
                }
            }
            for (int col = 0; col < cols; col++)
            {
                int sumOnCurrentCol = 0;
                for (int row = 0; row < rows; row++)
                {
                    sumOnCurrentCol += matrix[row, col];
                }
                Console.WriteLine(sumOnCurrentCol);
            }
        }
    }
}
