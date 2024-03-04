using System;

namespace for_next_ween_3._New_House
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string typeFlowers = Console.ReadLine();
            int flowersQuantity = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double totalPrice = 0;
            switch (typeFlowers)
            {
                case "Roses":
                    totalPrice = flowersQuantity * 5.00;
                    if(flowersQuantity > 80)
                    {
                        totalPrice -= totalPrice * 0.10;
                    }
                    break;
                case "Dahlias":
                    totalPrice = flowersQuantity * 3.80;
                    if (flowersQuantity > 90)
                    {
                        totalPrice -= totalPrice * 0.15;
                    }
                    break;
                case "Tulips":
                    totalPrice = flowersQuantity * 2.80;
                    if (flowersQuantity > 80)
                    {
                        totalPrice -= totalPrice * 0.15;
                    }
                    break;
                case "Narcissus":
                    totalPrice = flowersQuantity * 3.00;
                    if (flowersQuantity < 120)
                    {
                        totalPrice += totalPrice * 0.15;
                    }
                    break;
                case "Gladiolus":
                    totalPrice = flowersQuantity * 2.50;
                    if (flowersQuantity < 80)
                    {
                        totalPrice += totalPrice * 0.20;
                    }
                    break;
            }
            if(budget >= totalPrice)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowersQuantity} {typeFlowers} and {budget - totalPrice:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {totalPrice - budget:f2} leva more.");
            }
        }
    }
}
