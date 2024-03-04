using System;

namespace _01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputString = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Action<string[]> printWordsFromInput = words => Console.WriteLine(string.Join(Environment.NewLine, words));
            //Action<string> printWordsFromInput = word => Console.WriteLine(word);
            //for (int i = 0; i < inputString.Length; i++)
            //{
            //    printWordsFromInput(inputString[i]);
            //}
            printWordsFromInput(inputString);
        }
    }
}
