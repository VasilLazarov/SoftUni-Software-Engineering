using System;
using System.Linq;

namespace _06._Equal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int leftSum = 0;
            int rightSum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int v = 0; v < numbers.Length; v++)
                {
                    if (v < i)
                    {
                        leftSum += numbers[v];
                    }
                    else if (v > i)
                    {
                        rightSum += numbers[v];
                    }
                }
                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }
                leftSum = 0;
                rightSum = 0;
            }
            Console.WriteLine("no");
        }
    }
}
