using System;
using System.ComponentModel.Design;
using System.Data.Common;
using System.Linq;

namespace _06._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfRowsOfMatrix = int.Parse(Console.ReadLine());
            int[][] jaggedMatrix = new int[numOfRowsOfMatrix][];
            for (int row = 0; row < numOfRowsOfMatrix; row++)
            {
                jaggedMatrix[row] = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();
            }
            string input = Console.ReadLine();
            while(input != "END")
            {
                string[] inputElements = input.Split(" ");
                string command = inputElements[0];
                int row = int.Parse(inputElements[1]);
                int col = int.Parse(inputElements[2]);
                int value = int.Parse(inputElements[3]);
                if(row < 0 || row >= numOfRowsOfMatrix || col < 0 || col >= jaggedMatrix[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                    switch (command)
                    {
                        case "Add":
                            jaggedMatrix[row][col] += value;
                            break;
                        case "Subtract":
                            jaggedMatrix[row][col] -= value;
                            break;
                    }
                }
                input = Console.ReadLine();
            }
            foreach (int[] array in jaggedMatrix)
            {
                Console.WriteLine(String.Join(" ", array));
            }
        }
    }
}
