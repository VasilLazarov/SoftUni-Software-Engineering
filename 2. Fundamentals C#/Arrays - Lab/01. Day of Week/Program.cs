using System;

namespace _01._Day_of_Week
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] daysOfWeek = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};
            int num = int.Parse(Console.ReadLine());
            if(num < 1 || num > 7)
            {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                Console.WriteLine($"{daysOfWeek[num - 1]}");
            }
        }
    }
}
