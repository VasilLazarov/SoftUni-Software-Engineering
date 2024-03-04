using System;

namespace _06._Middle_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string middleLetter = string.Empty;
            Console.WriteLine(PrintMiddleCharacter(input, middleLetter));
        }

        static string PrintMiddleCharacter(string input, string middleLetter)
        {
            if(input.Length % 2 != 0)
            {
                middleLetter = input[input.Length/2].ToString();
            }
            else
            {
                middleLetter = input[input.Length / 2 - 1].ToString();
                middleLetter += input[input.Length / 2].ToString();
            }
            return middleLetter;
        }
    }
}
