using System;

namespace _3._New_House
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string typeFlowers = Console.ReadLine();
            int numFLowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double totalPrice = 0;
            switch (typeFlowers)
            {
                case "Roses":
                    totalPrice = numFLowers * 5.00;
                    if(numFLowers > 80)
                    {
                        totalPrice -= totalPrice * 0.10;
                    }
                    break;
                case "Dahlias":
                    totalPrice = numFLowers * 3.80;
                    if (numFLowers > 90)
                    {
                        totalPrice -= totalPrice * 0.15;
                    }
                    break;
                case "Tulips":
                    totalPrice = numFLowers * 2.80;
                    if (numFLowers > 80)
                    {
                        totalPrice -= totalPrice * 0.15;
                    }
                    break;
                case "Narcissus":
                    totalPrice = numFLowers * 3.00;
                    if (numFLowers < 120)
                    {
                        totalPrice += totalPrice * 0.15;
                    }
                    break;
                case "Gladiolus":
                    totalPrice = numFLowers * 2.50;
                    if (numFLowers < 80)
                    {
                        totalPrice += totalPrice * 0.20;
                    }
                    break;
            }
            if (budget >= totalPrice)
            {
                Console.WriteLine($"Hey, you have a great garden with {numFLowers} {typeFlowers} and {budget - totalPrice:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {totalPrice - budget:f2} leva more.");
            }
        }
    }
}
