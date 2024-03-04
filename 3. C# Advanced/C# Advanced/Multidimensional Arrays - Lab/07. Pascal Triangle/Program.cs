using System;

namespace _07._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfTriangle = int.Parse(Console.ReadLine());

            long[][] pascalTriangle = new long[sizeOfTriangle][];
            pascalTriangle[0] = new long[1];
            pascalTriangle[0][0] = 1;
            for (int row = 1; row < sizeOfTriangle; row++)
            {
                pascalTriangle[row] = new long[row + 1];
                for (int col = 0; col < row + 1; col++)
                {
                    long numForAdd = 0;
                    if (col < pascalTriangle[row - 1].Length)
                    {
                        numForAdd += pascalTriangle[row - 1][col];
                    }
                    if(col > 0)
                    {
                        numForAdd += pascalTriangle[row - 1][col - 1];
                    }
                    pascalTriangle[row][col] = numForAdd;
                }
            }
            foreach (long[] array in pascalTriangle)
            {
                Console.WriteLine(String.Join(" ", array));
            }
        }
    }
}
