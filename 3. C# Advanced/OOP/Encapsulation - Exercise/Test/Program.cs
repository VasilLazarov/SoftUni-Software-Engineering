using System;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Math.Round(0.49, MidpointRounding.AwayFromZero));
        }
    }
}
