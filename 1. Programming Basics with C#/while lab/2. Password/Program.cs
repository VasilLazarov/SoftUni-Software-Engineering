using System;

namespace _2._Password
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string truePassword = Console.ReadLine();

            string passForCheck = Console.ReadLine();
            while(passForCheck != truePassword)
            {
                passForCheck = Console.ReadLine();

            }
            Console.WriteLine($"Welcome {name}!");
            
        }
    }
}
