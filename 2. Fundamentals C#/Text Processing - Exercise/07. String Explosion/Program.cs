using System;

namespace _07._String_Explosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int bombStrength = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    bombStrength += int.Parse(input[i + 1].ToString());
                }
                else if(bombStrength > 0)
                {
                    input = input.Remove(i, 1);
                    bombStrength--;
                    i--;
                }
            }
            Console.WriteLine(input);
        }
    }
}
