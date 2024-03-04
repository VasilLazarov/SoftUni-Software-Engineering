using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            string input = string.Empty;
            while((input = Console.ReadLine()) != "End")
            {
                string[] inputArr = input.Split(" ");
                string command = inputArr[0];
                if(command == "Add")
                {
                    numbers.Add(int.Parse(inputArr[1]));
                }
                else if(command == "Insert")
                {
                    if (int.Parse(inputArr[2]) > (numbers.Count - 1) || int.Parse(inputArr[2]) < 0)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    numbers.Insert(int.Parse(inputArr[2]), int.Parse(inputArr[1]));
                }
                else if(command == "Remove")
                {
                    if (int.Parse(inputArr[1]) > (numbers.Count - 1) || int.Parse(inputArr[1]) < 0)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    numbers.RemoveAt(int.Parse(inputArr[1]));
                }
                else if(command == "Shift")
                {
                    ShiftRightOrLeft(numbers, inputArr[1], int.Parse(inputArr[2]));
                }
            }
            Console.WriteLine(String.Join(" ", numbers));
        }
        static void ShiftRightOrLeft(List<int> numbers, string direction, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (direction == "left")
                {
                    int numForShift = numbers[0];
                    numbers.RemoveAt(0);
                    numbers.Add(numForShift);
                }
                else if (direction == "right")
                {
                    int numForShift = numbers[numbers.Count-1];
                    numbers.RemoveAt(numbers.Count - 1);
                    numbers.Insert(0, numForShift);
                }
            }
        }
    }
}
