using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> inputNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToHashSet();   //we can orderby hashSet and get first number, but we want use Func<> now

            //Func<int[], int> minNumber = numbers => numbers.Min();   //with Linq


            //without Linq
            Func<HashSet<int>, int> minNumber = numbers =>
            {
                int min = int.MaxValue;
                foreach (int number in numbers)
                {
                    if(number < min)
                    {
                        min = number;
                    }
                }
                return min;
            };
            Console.WriteLine(minNumber(inputNumbers));
        }
    }
}
