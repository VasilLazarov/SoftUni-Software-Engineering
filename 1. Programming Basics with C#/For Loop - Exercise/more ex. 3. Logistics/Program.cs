using System;

namespace more_ex._3._Logistics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int weight = 0;
            double totalWeight = 0;
            int microbus = 0;
            int weightWithBus = 0;
            int truck = 0;
            int weightWithTruck = 0;
            int train = 0;
            int weightWithTrain = 0;
            double averageWeight = 0;
            for (int i = 1; i <= num; i++)
            {
                weight = int.Parse(Console.ReadLine());
                totalWeight += weight;
                if(weight <= 3)
                {
                    microbus++;
                    weightWithBus += weight;
                }
                else if(weight > 3 && weight <= 11)
                {
                    truck++;
                    weightWithTruck += weight;
                }
                else if(weight > 11)
                {
                    train++;
                    weightWithTrain += weight;
                }

            }
            averageWeight = (weightWithBus * 200.00 + weightWithTruck * 175.00 + weightWithTrain * 120.00) / totalWeight;
            Console.WriteLine($"{averageWeight:f2}");
            Console.WriteLine($"{(weightWithBus / totalWeight)*100:f2}%");
            Console.WriteLine($"{(weightWithTruck / totalWeight) * 100:f2}%");
            Console.WriteLine($"{(weightWithTrain / totalWeight) * 100:f2}%");
        }
    }
}
