using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();
            SortedDictionary<double, int> countOfEveryNumber 
                = new SortedDictionary<double, int>();
            foreach (double number in numbers)
            {
                if (!countOfEveryNumber.ContainsKey(number))
                {
                    countOfEveryNumber.Add(number, 0);
                }
                countOfEveryNumber[number]++;
            }
            foreach(var current in countOfEveryNumber)
            {
                Console.WriteLine($"{current.Key} -> {current.Value}");
            }
        }
    }
}
