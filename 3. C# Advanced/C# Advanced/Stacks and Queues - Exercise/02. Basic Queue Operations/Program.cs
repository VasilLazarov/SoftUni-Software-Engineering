using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputCommands = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int numOfElementsToEnqueue = inputCommands[0];
            int numOfElementsToDequeue = inputCommands[1];
            int numberSought = inputCommands[2];

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queueOfNumbers = new Queue<int>();

            for (int i = 0; i < numOfElementsToEnqueue; i++)
            {
                queueOfNumbers.Enqueue(numbers[i]);
            }
            for (int i = 0; i < numOfElementsToDequeue; i++)
            {
                queueOfNumbers.Dequeue();
            }
            if (queueOfNumbers.Contains(numberSought))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queueOfNumbers.Any())
                {
                    Console.WriteLine(queueOfNumbers.Min());
                }
                else
                {
                    Console.WriteLine("0");
                }
            }
        }
    }
}
