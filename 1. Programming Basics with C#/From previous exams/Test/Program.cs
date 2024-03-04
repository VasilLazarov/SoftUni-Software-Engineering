using System;

namespace _05._Suitcases_Load
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double capacity = double.Parse(Console.ReadLine()); // капацитет на багажника
            string input = Console.ReadLine(); // вх. данни
            double count = 0; // брой натоварени багажи
            while (input != "End")
            {
                double suitcaseSize = double.Parse(input); // обем на куфара
                capacity -= suitcaseSize;
                if (capacity > 0)
                {
                    count++;
                    if (count % 3 == 0)
                    {
                        suitcaseSize = suitcaseSize + 0.10;
                    }
                    input = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"No more space!");
                    break;
                }
            }
            if (input == "End")
            {
                Console.WriteLine($"Congratulations! All suitcases are loaded!");
            }
            Console.WriteLine($"Statistic: {count} suitcases loaded.");
        }
    }
}

