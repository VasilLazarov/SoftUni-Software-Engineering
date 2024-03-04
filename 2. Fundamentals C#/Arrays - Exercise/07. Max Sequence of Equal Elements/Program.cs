using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int sequence = 1;
            int maxSequence = sequence;
            int indexForPrint = 0;
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    sequence++;
                }
                else
                {
                    sequence = 1;

                }
                if(sequence > maxSequence)
                {
                    maxSequence = sequence;
                    indexForPrint = i;
                }
            }
            for(int i = 0; i < maxSequence; i++)
            {
                Console.Write(numbers[indexForPrint]);
                if(i < numbers.Length - 1)
                {
                    Console.Write(" ");
                }
            }
        }
    }
}
