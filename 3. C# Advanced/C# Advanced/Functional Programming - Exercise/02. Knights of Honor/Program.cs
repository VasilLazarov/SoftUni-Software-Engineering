using System;

namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputNames = Console.ReadLine()
                .Split();

            Action<string[], string> printNames = (names, title) =>      //PrintNames(names);
            {
                foreach (var name in names)
                {
                    Console.WriteLine($"{title} {name}");
                }
            };              

            printNames(inputNames, "Sir");
            //printNames(inputNames, "Madam");
        }

        //private static void PrintNames(string[] names)
        //{
        //    foreach (var name in names)
        //    {
        //        Console.WriteLine($"Sir {name}");
        //    }
        //}
    }
}
