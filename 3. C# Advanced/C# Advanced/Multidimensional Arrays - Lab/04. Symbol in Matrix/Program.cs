using System;

namespace _04._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizeOfMatrix, sizeOfMatrix];
            
            for (int row = 0; row < sizeOfMatrix; row++)
            {
                string elementsOfThisRow = Console.ReadLine();
                for (int col = 0; col < sizeOfMatrix; col++)
                {
                    matrix[row, col] = elementsOfThisRow[col];
                }
            }
            char symbolForFinding = char.Parse(Console.ReadLine());
            for (int row = 0; row < sizeOfMatrix; row++)
            {
                for (int col = 0; col < sizeOfMatrix; col++)
                {
                    if(matrix[row, col] == symbolForFinding)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{symbolForFinding} does not occur in the matrix");
        }
    }
}
