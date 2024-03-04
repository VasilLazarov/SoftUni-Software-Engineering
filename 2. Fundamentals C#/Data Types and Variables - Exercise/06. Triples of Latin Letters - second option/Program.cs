using System;

namespace _06._Triples_of_Latin_Letters___second_option
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (char i = 'a'; i < ('a' + n); i++)
            {
                for (char l = 'a'; l < ('a' + n); l++)
                {
                    for (char v = 'a'; v < ('a' + n); v++)
                    {
                        Console.WriteLine($"{(char)i}{(char)l}{(char)v}");
                    }
                }
            }
        }
    }
}
