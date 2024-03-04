using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbersRange = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string typeNumbers = Console.ReadLine();

            // simple
            //List<int> numbers = new List<int>();
            //for (int i = numbersRange[0]; i <= numbersRange[1]; i++)
            //{
            //    numbers.Add(i);
            //}

            // difficult, but now we learning Func<> and we want to use it
            Func<int, int, List<int>> generateNumbersFromRange = (start, end) =>
            {
                List<int> numbers = new List<int>();
                for (int i = start; i <= end; i++)
                {
                    numbers.Add(i);
                }
                return numbers;
            };
            List<int> numbers = generateNumbersFromRange(numbersRange[0], numbersRange[1]);



            Predicate<int> evenOrOdd = EvenOrOdd(typeNumbers);
            numbers = numbers.Where(v => evenOrOdd(v)).ToList();

            Console.WriteLine(String.Join(" ", numbers));

        }

        static Predicate<int> EvenOrOdd(string typeNumbers)
        {
            switch (typeNumbers)
            {
                case "even":
                    return p => p % 2 == 0;
                case "odd":
                    return p => p % 2 != 0;
                default:
                    return null;
            }
        }
    }
}
