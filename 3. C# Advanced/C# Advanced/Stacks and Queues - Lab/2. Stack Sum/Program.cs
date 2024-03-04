using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] startNumbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            Stack<int> numbers = new Stack<int>(startNumbers);

            string input = Console.ReadLine().ToLower();
            while(input != "end")
            {
                string[] inputElements = input.Split(" ");
                string command = inputElements[0];
                if(command == "add")
                {
                    int number1 = int.Parse(inputElements[1]);
                    int number2 = int.Parse(inputElements[2]);
                    numbers.Push(number1);
                    numbers.Push(number2);
                }
                else if (command == "remove")
                {
                    int n = int.Parse(inputElements[1]);
                    if(n <= numbers.Count)
                    {
                        for (int i = 1; i <= n; i++)
                        {
                            numbers.Pop();
                        }
                    }
                }
                input = Console.ReadLine().ToLower();
            }
            int sum = 0;
            int count = numbers.Count;
            for (int i = 0; i < count; i++)
            {
                sum += numbers.Pop();
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
