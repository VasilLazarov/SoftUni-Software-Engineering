using System;
using System.Linq;

namespace _05._Top_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            bool bigInteger = true;
            for(int i = 0; i < numbers.Length; i++)
            {
                for(int v = i + 1; v < numbers.Length; v++)
                {
                    if(numbers[i] <= numbers[v])
                    {
                        bigInteger = false;
                    }
                }
                if (bigInteger)
                {
                    Console.Write($"{numbers[i]} ");
                }
                bigInteger = true;
            }
        }
    }
}
