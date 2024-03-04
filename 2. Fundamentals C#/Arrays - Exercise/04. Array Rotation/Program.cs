using System;
using System.Linq;

namespace _04._Array_Rotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int numOfRotations = int.Parse(Console.ReadLine());
            for(int v = 0; v < numOfRotations; v++)
            {
                int firstElement = numbers[0];
                for (int l = 1; l < numbers.Length; l++)
                {
                    numbers[l - 1] = numbers[l];
                }
                numbers[numbers.Length - 1] = firstElement;
            }
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
