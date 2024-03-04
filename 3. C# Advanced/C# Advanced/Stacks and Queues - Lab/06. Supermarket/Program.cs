using System;
using System.Collections.Generic;

namespace _06._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> customers = new Queue<string>();
            string input = Console.ReadLine();
            while(input != "End")
            {
                if(input == "Paid")
                {
                    while(customers.Count > 0)
                    {
                        Console.WriteLine(customers.Dequeue());
                    }
                    customers.Clear();
                }
                else
                {
                    customers.Enqueue(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}
