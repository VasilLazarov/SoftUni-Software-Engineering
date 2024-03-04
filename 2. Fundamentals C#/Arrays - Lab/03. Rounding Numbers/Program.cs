using System;
using System.Linq;

namespace _03._Rounding_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] realNumbers = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();
            int[] roundedNumbers = new int[realNumbers.Length];
            for (int i = 0; i < realNumbers.Length; i++)
            {
                roundedNumbers[i] = (int)Math.Round(realNumbers[i], MidpointRounding.AwayFromZero);
                Console.WriteLine($"{realNumbers[i]} => {roundedNumbers[i]}");
            }


        }
    }
}
