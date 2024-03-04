using System;

namespace a15._Painting_Eggs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string size = Console.ReadLine();
            string color = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());
            double totalPrice = 0;
            double profit = 0;
            switch (color)
            {
                case "Red":
                    switch (size)
                    {
                        case "Large":
                            totalPrice = number * 16;
                            break;
                        case "Medium":
                            totalPrice = number * 13;
                            break;
                        case "Small":
                            totalPrice = number * 9;
                            break;
                    }
                    break;
                case "Green":
                    switch (size)
                    {
                        case "Large":
                            totalPrice = number * 12;
                            break;
                        case "Medium":
                            totalPrice = number * 9;
                            break;
                        case "Small":
                            totalPrice = number * 8;
                            break;
                    }
                    break;
                case "Yellow":
                    switch (size)
                    {
                        case "Large":
                            totalPrice = number * 9;
                            break;
                        case "Medium":
                            totalPrice = number * 7;
                            break;
                        case "Small":
                            totalPrice = number * 5;
                            break;
                    }
                    break;
            }
            profit = totalPrice * 0.65;
            Console.WriteLine($"{profit:f2} leva.");
        }
    }
}
