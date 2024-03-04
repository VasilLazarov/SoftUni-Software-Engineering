using System;
using System.Linq;

namespace _02._Rally_Racing
{
    public class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());
            string racingNumber = Console.ReadLine();

            char[,] trace = ReadMatrix(sizeMatrix);

            trace[0, 0] = 'C';

            string command = Console.ReadLine();
            int totalKilometers = 0;
            int currentRow = 0;
            int currentCol = 0;
            char currentChar = '.';
            bool finish = false;
            while (command != "End")
            {
                switch (command)
                {
                    case "left":
                        trace[currentRow, currentCol] = '.';
                        currentCol--;
                        break;
                    case "right":
                        trace[currentRow, currentCol] = '.';
                        currentCol++;
                        break;
                    case "up":
                        trace[currentRow, currentCol] = '.';
                        currentRow--;
                        break;
                    case "down":
                        trace[currentRow, currentCol] = '.';
                        currentRow++;
                        break;
                }
                currentChar = trace[currentRow, currentCol];
                if (currentChar == '.')
                {
                    trace[currentRow, currentCol] = 'C';
                    totalKilometers += 10;
                }
                else if (currentChar == 'T')
                {
                    trace[currentRow, currentCol] = '.';
                    string[] cordinates = FindCordinatesOfOtherT(trace).Split(" ");
                    currentRow = int.Parse(cordinates[0]);
                    currentCol = int.Parse(cordinates[1]);
                    trace[currentRow, currentCol] = 'C';
                    totalKilometers += 30;
                }
                else if (currentChar == 'F')
                {
                    trace[currentRow, currentCol] = 'C';
                    finish = true;
                    totalKilometers += 10;
                }
                if (finish)
                {
                    Console.WriteLine($"Racing car {racingNumber} finished the stage!");
                    Console.WriteLine($"Distance covered {totalKilometers} km.");
                    break;
                }
                command = Console.ReadLine();
            }
            if (!finish)
            {
                Console.WriteLine($"Racing car {racingNumber} DNF.");
                Console.WriteLine($"Distance covered {totalKilometers} km.");
            }
            PrintMatrix(trace);
        }

        static char[,] ReadMatrix(int sizeMatrix)
        {
            char[,] matrix = new char[sizeMatrix, sizeMatrix];
            for (int row = 0; row < sizeMatrix; row++)
            {
                char[] inputCurrentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < sizeMatrix; col++)
                {
                    matrix[row, col] = inputCurrentRow[col];
                }
            }
            return matrix;
        }

        static string FindCordinatesOfOtherT(char[,] trace)
        {
            string cordinates = string.Empty;
            for (int i = 0; i < trace.GetLength(0); i++)
            {
                for (int v = 0; v < trace.GetLength(1); v++)
                {
                    if (trace[i, v] == 'T')
                    {
                        cordinates = $"{i} {v}";
                    }
                }
            }
            return cordinates;
        }

        static void PrintMatrix(char[,] trace)
        {
            for (int row = 0; row < trace.GetLength(0); row++)
            {
                for (int col = 0; col < trace.GetLength(1); col++)
                {
                    Console.Write($"{trace[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
