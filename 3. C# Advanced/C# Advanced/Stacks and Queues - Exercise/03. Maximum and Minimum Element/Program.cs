using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>();

            int numberOfQueries = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numberOfQueries; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();
                int command = input[0];
                switch (command)
                {
                    case 1:
                        int number = input[1];
                        numbers.Push(number);
                        break;
                    case 2:
                        if (numbers.Any())
                        {
                            numbers.Pop();
                        }
                        break;
                    case 3:
                        if (numbers.Any())
                        {
                            Console.WriteLine(numbers.Max());
                        }
                        break;
                    case 4:
                        if (numbers.Any())
                        {
                            Console.WriteLine(numbers.Min());
                        }
                        break;
                }
            }
            Console.WriteLine(String.Join(", ", numbers));
        }
    }
}
