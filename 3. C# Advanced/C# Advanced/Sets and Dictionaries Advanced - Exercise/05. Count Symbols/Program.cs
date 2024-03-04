using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> countOfSymbols = new SortedDictionary<char, int>();
            string inputText = Console.ReadLine();
            for (int i = 0; i < inputText.Length; i++)
            {
                char currentSymbol = inputText[i];
                if (!countOfSymbols.ContainsKey(currentSymbol))
                {
                    countOfSymbols.Add(currentSymbol, 0);
                }
                countOfSymbols[currentSymbol]++;
            }
            foreach(var symbol in countOfSymbols)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
