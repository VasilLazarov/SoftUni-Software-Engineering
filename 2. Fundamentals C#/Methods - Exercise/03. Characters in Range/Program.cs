using System;

namespace _03._Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char symbol1 = char.Parse(Console.ReadLine());
            char symbol2 = char.Parse(Console.ReadLine());
            if(symbol1 > symbol2)
            {
                (symbol2, symbol1) = (symbol1, symbol2);
            }
            PrintCharactersBetween(symbol1, symbol2);
        }

        static void PrintCharactersBetween(char symbol1, char symbol2)
        {
            for (int i = symbol1 + 1; i < symbol2; i++)
            {
                char print = (char)i;
                Console.Write($"{print} ");
            }
        }

    }
}
