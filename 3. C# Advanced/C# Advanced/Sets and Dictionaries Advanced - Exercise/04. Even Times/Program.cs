using System;
using System.Collections.Generic;

namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbersCounts = new Dictionary<int, int>();
            int countOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfInputs; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (!numbersCounts.ContainsKey(number))
                {
                    numbersCounts.Add(number, 0);
                }
                numbersCounts[number]++;
            }
            foreach (var item in numbersCounts)     //whitout foreach we can use
            {                                       //cw(numbersCounts.Single(v => v.Value %2 == 0).Key)
                if(item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                    break;
                }
            }

        }
    }
}
