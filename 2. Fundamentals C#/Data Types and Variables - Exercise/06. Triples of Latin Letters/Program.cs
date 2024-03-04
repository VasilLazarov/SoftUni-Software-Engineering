using System;

namespace _06._Triples_of_Latin_Letters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 97; i < (97 + n); i++)
            {
                for (int l = 97; l < (97 + n); l++)
                {
                    for (int v = 97; v < (97 + n); v++)
                    {
                        Console.WriteLine($"{(char)i}{(char)l}{(char)v}");
                    }
                }
            }
        }
    }
}
