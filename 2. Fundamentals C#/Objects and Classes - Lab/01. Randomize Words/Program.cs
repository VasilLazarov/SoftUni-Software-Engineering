using System;

namespace _01._Randomize_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ");
            Random number = new Random();
            for (int i = 0; i < input.Length; i++)
            {
                int position = number.Next(0, input.Length);
                string wordForMove = input[i];
                input[i] = input[position];
                input[position] = wordForMove;
            }
            Console.WriteLine(string.Join(Environment.NewLine, input));
        }
    }
}
