using System;
using System.Collections.Generic;

namespace _07._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputKids = Console.ReadLine().Split(" ");
            int hotNumber = int.Parse(Console.ReadLine());
            Queue<string> kids = new Queue<string>(inputKids);
            int tossCount = 1;
            while(kids.Count > 1)
            {
                if(hotNumber == tossCount)
                {
                    Console.WriteLine($"Removed {kids.Dequeue()}");
                    tossCount = 1;
                }
                else
                {
                    tossCount++;
                    string currentKid = kids.Dequeue();
                    kids.Enqueue(currentKid);
                }
            }
            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
