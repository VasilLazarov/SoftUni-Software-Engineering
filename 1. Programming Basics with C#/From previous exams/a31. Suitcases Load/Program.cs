using System;

namespace a31._Suitcases_Load
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double capacity = double.Parse(Console.ReadLine());
            string volumOfSuitcase = Console.ReadLine();
            double suitcaseVolume = 0;
            int count = 0;
            while(volumOfSuitcase != "End")
            {
                suitcaseVolume = double.Parse(volumOfSuitcase);
                count++;
                if(count % 3 == 0)
                {
                    suitcaseVolume *= 1.10;
                }
                if (capacity < suitcaseVolume)
                {
                    Console.WriteLine("No more space!");
                    Console.WriteLine($"Statistic: {count - 1} suitcases loaded.");
                    return;
                }
                capacity -= suitcaseVolume;

                volumOfSuitcase = Console.ReadLine();
            }
            Console.WriteLine("Congratulations! All suitcases are loaded!");
            Console.WriteLine($"Statistic: {count} suitcases loaded.");
        }
    }
}
