using System;

namespace _4._Vacation_Books_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pages = int.Parse(Console.ReadLine());
            int pagesPerHour = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int hoursPerDay = (pages/pagesPerHour)/days;
            Console.WriteLine(hoursPerDay);
        }
    }
}
