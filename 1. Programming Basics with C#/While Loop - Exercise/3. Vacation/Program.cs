using System;

namespace _3._Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            string action = "";
            double sum = 0;
            int count = 0;
            int days = 0;
            while(budget < neededMoney)
            {
                action = Console.ReadLine();
                sum = double.Parse(Console.ReadLine());
                days++;
                if(action == "save")
                {
                    budget += sum;
                    count = 0;
                }
                else if(action == "spend")
                {
                    budget -= sum;
                    count++;
                    if(budget < 0)
                    {
                        budget = 0;
                    }
                }
                if(count == 5)
                {
                    Console.WriteLine($"You can't save the money.");
                    Console.WriteLine($"{days}");
                    return;
                }
            }
            Console.WriteLine($"You saved the money for {days} days.");

        }
    }
}
