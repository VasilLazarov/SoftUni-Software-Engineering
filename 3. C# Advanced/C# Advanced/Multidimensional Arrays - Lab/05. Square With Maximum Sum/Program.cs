using System;
using System.Linq;
using System.Runtime.Versioning;

namespace _05._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int subMartixRows = 2;
            int subMartixCols = 2;
            int[] matrixSizes = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int rows = matrixSizes[0];
            int cols = matrixSizes[1];
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                int[] numbersForThisRow = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
                for (int col = 0; col < cols; col++)
                {
                     matrix[row, col] = numbersForThisRow[col];
                }
            }
            int maxSum = 0;
            int startingRow = 0;
            int startingCol = 0;
            for (int row = 0; row <= rows - subMartixRows; row++)
            {
                for (int col = 0; col <= cols - subMartixCols; col++)
                {
                    int currentSum = 0;
                    for (int subRow = 0; subRow < subMartixRows; subRow++)
                    {
                        for (int subCol = 0; subCol < subMartixCols; subCol++)
                        {
                            currentSum += matrix[row + subRow, col + subCol];
                        }
                    }
                    if(currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        startingRow = row;
                        startingCol = col;
                    }
                }
            }
            for (int row = 0; row < subMartixRows; row++)
            {
                for (int col = 0; col < subMartixCols; col++)
                {
                    Console.Write(matrix[startingRow + row, startingCol + col] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(maxSum);
        }
    }
}
