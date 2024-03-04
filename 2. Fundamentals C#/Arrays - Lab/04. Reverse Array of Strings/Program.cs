using System;
using System.Linq;

namespace _04._Reverse_Array_of_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] symbols = Console.ReadLine().Split(' ').ToArray();
            Array.Reverse(symbols);
            Console.WriteLine(string.Join(" ",symbols));
        }
    }
}
