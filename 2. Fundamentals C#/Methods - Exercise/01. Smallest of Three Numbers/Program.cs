using System;
using System.Linq;

namespace _01._Smallest_of_Three_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[3];
            for (int i = 0; i < 3; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(SmallestOfThreeIntegrs(numbers));
        }

        static int SmallestOfThreeIntegrs(int[] numbers)
        {
            int smallestNum = int.MaxValue;
            for (int i = 0; i < 3; i++)
            {
                if (numbers[i] < smallestNum)
                {
                    smallestNum = numbers[i];
                }
            }
            return smallestNum;
        }
    }
}
