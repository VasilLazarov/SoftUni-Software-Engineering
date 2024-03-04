using System;

namespace a30._Series
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            double totalPrice = 0;
            string name = "";
            double price = 0;
            for(int i = 0; i < n; i++)
            {
                name = Console.ReadLine();
                price = double.Parse(Console.ReadLine());
                switch (name)
                {
                    case "Thrones":
                        totalPrice += price - price * 0.50;
                        break;
                    case "Lucifer":
                        totalPrice += price - price * 0.40;
                        break;
                    case "Protector":
                        totalPrice += price - price * 0.30;
                        break;
                    case "TotalDrama":
                        totalPrice += price - price * 0.20;
                        break;
                    case "Area":
                        totalPrice += price - price * 0.10;
                        break;
                    default:
                        totalPrice += price;
                        break;
                }
            }
            if(budget >= totalPrice)
            {
                Console.WriteLine($"You bought all the series and left with {budget - totalPrice:f2} lv.");
            }
            else
            {
                Console.WriteLine($"You need {totalPrice - budget:f2} lv. more to buy the series!");
            }
        }
    }
}
