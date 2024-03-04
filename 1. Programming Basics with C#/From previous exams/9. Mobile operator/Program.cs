using System;

namespace _9._Mobile_operator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string term = Console.ReadLine();
            string contractType = Console.ReadLine();
            string internet = Console.ReadLine();
            int months = int.Parse(Console.ReadLine());
            double totalPrice = 0;
            if(term == "one")
            {
                switch (contractType)
                {
                    case "Small":
                        if(internet == "yes")
                        {
                            totalPrice = (9.98 + 5.50) * months;
                        }
                        else
                        {
                            totalPrice = 9.98 * months;
                        }
                        break;
                    case "Middle":
                        if (internet == "yes")
                        {
                            totalPrice = (18.99 + 4.35) * months;
                        }
                        else
                        {
                            totalPrice = 18.99 * months;
                        }
                        break;
                    case "Large":
                        if (internet == "yes")
                        {
                            totalPrice = (25.98 + 4.35) * months;
                        }
                        else
                        {
                            totalPrice = 25.98 * months;
                        }
                        break;
                    case "ExtraLarge":
                        if (internet == "yes")
                        {
                            totalPrice = (35.99 + 3.85) * months;
                        }
                        else
                        {
                            totalPrice = 35.99 * months;
                        }
                        break;
                }
            }
            else if(term == "two")
            {
                switch (contractType)
                {
                    case "Small":
                        if (internet == "yes")
                        {
                            totalPrice = (8.58 + 5.50) * months;
                        }
                        else
                        {
                            totalPrice = 8.58 * months;
                        }
                        break;
                    case "Middle":
                        if (internet == "yes")
                        {
                            totalPrice = (17.09 + 4.35) * months;
                        }
                        else
                        {
                            totalPrice = 17.09 * months;
                        }
                        break;
                    case "Large":
                        if (internet == "yes")
                        {
                            totalPrice = (23.59 + 4.35) * months;
                        }
                        else
                        {
                            totalPrice = 23.59 * months;
                        }
                        break;
                    case "ExtraLarge":
                        if (internet == "yes")
                        {
                            totalPrice = (31.79 + 3.85) * months;
                        }
                        else
                        {
                            totalPrice = 31.79 * months;
                        }
                        break;
                }
                totalPrice -= totalPrice * 0.0375;
            }
            Console.WriteLine($"{totalPrice:f2} lv.");
        }
    }
}
