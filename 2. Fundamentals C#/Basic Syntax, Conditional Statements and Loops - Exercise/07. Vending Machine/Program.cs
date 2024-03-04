using System;

namespace _07._Vending_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double coin = 0;
            double money = 0;

            while(input != "Start")
            {
                coin = double.Parse(input);
                switch(coin)
                {
                    case 0.1:
                    case 0.2:
                    case 0.5:
                    case 1.0:
                    case 2.0:
                        money += coin;
                        break;
                    default:
                        Console.WriteLine($"Cannot accept {coin}");
                        break;
                }
                input = Console.ReadLine();

            }
            input = Console.ReadLine();
            while(input != "End")
            {
                switch (input)
                {
                    case "Nuts":
                        if(money >= 2.0)
                        {
                            Console.WriteLine($"Purchased {input.ToLower()}");
                            money -= 2.0;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Water":
                        if (money >= 0.7)
                        {
                            Console.WriteLine($"Purchased {input.ToLower()}");
                            money -= 0.7;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Crisps":
                        if (money >= 1.5)
                        {
                            Console.WriteLine($"Purchased {input.ToLower()}");
                            money -= 1.5;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Soda":
                        if (money >= 0.8)
                        {
                            Console.WriteLine($"Purchased {input.ToLower()}");
                            money -= 0.8;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Coke":
                        if (money >= 1.0)
                        {
                            Console.WriteLine($"Purchased {input.ToLower()}");
                            money -= 1.0;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        break;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Change: {money:f2}");
        }
    }
}
