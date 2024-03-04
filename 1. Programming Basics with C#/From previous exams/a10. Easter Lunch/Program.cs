using System;

namespace a10._Easter_Lunch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int kozunaci = int.Parse(Console.ReadLine());
            int eggs = int.Parse(Console.ReadLine());
            int kurabiiKg = int.Parse(Console.ReadLine());
            double total = kozunaci * 3.20 + eggs * 4.35 + kurabiiKg * 5.40 + eggs * 12 * 0.15;
            Console.WriteLine($"{total:f2}");
        }
    }
}
