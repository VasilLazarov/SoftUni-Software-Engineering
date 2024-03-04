using System;

namespace _5._Character_Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            for(int k = 0; k < word.Length; k++)
            {
                char letter = word[k];
                Console.WriteLine(letter);
            }
        }
    }
}
