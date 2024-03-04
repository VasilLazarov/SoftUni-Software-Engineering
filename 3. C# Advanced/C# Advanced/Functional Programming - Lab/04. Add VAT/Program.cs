using System;
using System.Linq;

namespace _04._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] prices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(v => v * 1.2)
                .ToArray();
            foreach (var pr in prices)
            {
                Console.WriteLine($"{pr:f2}");
            }
        }
    }
}
