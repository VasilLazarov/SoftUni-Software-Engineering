using System;

namespace _3._Time___15_Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            minutes = minutes + 15;
            if(minutes > 59)
            {
                hours += 1;
                minutes -= 60;

            }
            int hoursForPrint = hours % 24;
            Console.WriteLine($"{hoursForPrint}:{minutes:d2}");
        }
    }
}
