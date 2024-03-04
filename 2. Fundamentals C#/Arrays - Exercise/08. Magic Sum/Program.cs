using System;
using System.Linq;

namespace _08._Magic_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int targetSum = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int v = i + 1; v < numbers.Length; v++)
                {
                    sum = numbers[i] + numbers[v];
                    if(sum == targetSum)
                    {
                        Console.WriteLine($"{numbers[i]} {numbers[v]}");
                    }
                }
            }
        }
    }
}
