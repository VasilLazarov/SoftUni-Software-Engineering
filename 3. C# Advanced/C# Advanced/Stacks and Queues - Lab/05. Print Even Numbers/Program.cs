using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            Queue<int> queueNumbers = new Queue<int>(numbers);
            bool firstNum = true;
            while(queueNumbers.Count > 0)
            {
                int currentNum = queueNumbers.Dequeue();
                if (currentNum % 2 == 0)
                {
                    if(firstNum == true)
                    {
                        Console.Write(currentNum);
                        firstNum = false;
                    }
                    else
                    {
                        Console.Write($", {currentNum}");
                    }
                }
            }
        }
    }
}
