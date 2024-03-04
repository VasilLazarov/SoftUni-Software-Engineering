using System;
using System.Collections.Generic;

namespace _06._Record_Unique_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> uniqueNames = new HashSet<string>();
            int countOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfInputs; i++)
            {
                string inputName = Console.ReadLine();
                uniqueNames.Add(inputName);
            }
            foreach (string inputName in uniqueNames)
            {
                Console.WriteLine(inputName);
            }
        }
    }
}
