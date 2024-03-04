using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> countSameValues = new Dictionary<double, int>();

            double[] inputValues = Console.ReadLine()
                .Split(" ")
                .Select(double.Parse)
                .ToArray();

            foreach (double value in inputValues)
            {
                if (!countSameValues.ContainsKey(value))
                {
                    countSameValues.Add(value, 1);
                }
                else
                {
                    countSameValues[value]++;
                }
            }
            foreach(var item in countSameValues)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }

        }
    }
}
