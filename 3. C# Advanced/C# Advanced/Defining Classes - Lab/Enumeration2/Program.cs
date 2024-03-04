using System;

namespace Enumeration2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Day day = Day.Monday;
            Console.WriteLine((int)day);
        }
        enum Day
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
    }
}
