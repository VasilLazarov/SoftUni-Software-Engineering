using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputCommands = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int numOfElementsForPush = inputCommands[0];
            int numOfElementsToPop = inputCommands[1];
            int numberSought = inputCommands[2];

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stackOfNumbers = new Stack<int>();

            for (int i = 0; i < numOfElementsForPush; i++)
            {
                stackOfNumbers.Push(numbers[i]);
            }
            for (int i = 0; i < numOfElementsToPop; i++)
            {
                stackOfNumbers.Pop();
            }
            if (stackOfNumbers.Contains(numberSought))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stackOfNumbers.Any())
                {
                    Console.WriteLine(stackOfNumbers.Min());
                }
                else
                {
                    Console.WriteLine("0");
                }
            }
        }
    }
}
