using System;

namespace _04._Back_In_30_Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            minutes += 30;
            if(minutes > 59)
            {
                hour++;
                minutes -= 60;
            }
            Console.WriteLine($"{hour%24}:{minutes:d2}");
        }
    }
}
