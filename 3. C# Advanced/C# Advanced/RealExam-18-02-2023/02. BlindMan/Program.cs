using System;
using System.Linq;

namespace _02._BlindMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrayDimmentions = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int rows = arrayDimmentions[0];
            int cols = arrayDimmentions[1];

            char[,] area = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                char[] currentLine = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int v = 0; v < cols; v++)
                {
                    area[i, v] = currentLine[v];
                }
            }
            int[] currentPosition = FindStartPosition(area)
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int startRow = currentPosition[0];
            int startCol = currentPosition[1];
            int currentRow = startRow;
            int currentCol = startCol;
            int countOfMoves = 0;
            int countOfTouches = 0;

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Finish")
            {
                switch (command)
                {
                    case "left":
                        currentCol--;
                        break;
                    case "right":
                        currentCol++;
                        break;
                    case "up":
                        currentRow--;
                        break;
                    case "down":
                        currentRow++;
                        break;
                }
                if(ChechPositionIsInAreaAndNotObstacle(area, currentRow, currentCol))
                {
                    if (area[currentRow, currentCol] == 'P')
                    {
                        countOfTouches++;
                        area[startRow, startCol] = '-';
                        area[currentRow, currentCol] = 'B';
                    }
                    else
                    {
                        area[startRow, startCol] = '-';
                        area[currentRow, currentCol] = 'B';
                    }
                    startRow = currentRow;
                    startCol = currentCol;
                    countOfMoves++;
                    //PrintMatrix(area);   // for debugging
                    //Console.WriteLine($"Moves: {countOfMoves}");
                    //Console.WriteLine($"Touches: {countOfTouches}");
                    if(countOfTouches == 3)
                    {
                        break;
                    }
                }
                else
                {
                    currentRow = startRow;
                    currentCol = startCol;
                }
            }
            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {countOfTouches} Moves made: {countOfMoves}");
        }

        static bool ChechPositionIsInAreaAndNotObstacle(char[,] area, int currentRow, int currentCol)
        {
            bool isPositionCorrect = true;

            if(currentRow < 0 || currentRow >= area.GetLength(0) || currentCol < 0 || currentCol >= area.GetLength(1))
            {
                isPositionCorrect = false;
            }
            else if(area[currentRow, currentCol] == 'O')
            {
                isPositionCorrect = false;
            }
                return isPositionCorrect;
        }

        static string FindStartPosition(char[,] area)
        {
            string position = string.Empty;
            bool finded = false;
            for (int i = 0; i < area.GetLength(0); i++)
            {
                for (int v = 0; v < area.GetLength(1); v++)
                {
                    if(area[i, v] == 'B')
                    {
                        position = $"{i} {v}";
                        finded = true;
                        break;
                    }
                }
                if (finded)
                {
                    break;
                }
            }
            return position;
        }
        //static void PrintMatrix(char[,] trace) //for debugging
        //{
        //    for (int row = 0; row < trace.GetLength(0); row++)
        //    {
        //        for (int col = 0; col < trace.GetLength(1); col++)
        //        {
        //            Console.Write($"{trace[row, col]}");
        //        }
        //        Console.WriteLine();
        //    }
        //}
    }
}
