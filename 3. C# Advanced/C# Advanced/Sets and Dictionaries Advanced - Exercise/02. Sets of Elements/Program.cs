using System;
using System.Collections.Generic;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> numbers1 = new HashSet<int>();
            HashSet<int> numbers2 = new HashSet<int>();
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int countOfNums1 = int.Parse(input[0]);
            int countOfNums2 = int.Parse(input[1]);
            int count = 0;

            for (int i = 0; i < countOfNums1; i++)
            {
                 int currentNumber = int.Parse(Console.ReadLine());
                numbers1.Add(currentNumber);
            }
            for (int i = 0; i < countOfNums2; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                numbers2.Add(currentNumber);
            }
            foreach (int numberFromFirstSet in numbers1)
            {
                foreach (int numberFromSecondSet in numbers2)
                {
                    if (numberFromFirstSet == numberFromSecondSet)
                    {
                        if (count > 0)
                        {
                            Console.Write(" ");
                        }
                        count++;
                        Console.Write(numberFromFirstSet);
                    }
                }
            }
        }
    }
}
