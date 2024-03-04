using System;

namespace _5._Coffee_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string drink = Console.ReadLine();
            string sugar = Console.ReadLine();
            int numOfDrinks = int.Parse(Console.ReadLine());
            double total = 0;
            if(sugar == "Without")
            {
                switch (drink)
                {
                    case "Espresso":
                        total = numOfDrinks * 0.90;
                        total -= total * 0.35;
                        if (numOfDrinks >= 5)
                        {
                            total -= total * 0.25;
                        }
                        break;
                    case "Cappuccino":
                        total = numOfDrinks * 1.00;
                        total -= total * 0.35;
                        break;
                    case "Tea":
                        total = numOfDrinks * 0.50;
                        total -= total * 0.35;
                        break;
                }
                
            }
            else if(sugar == "Normal")
            {
                switch (drink)
                {
                    case "Espresso":
                        total = numOfDrinks * 1.00;
                        if (numOfDrinks >= 5)
                        {
                            total -= total * 0.25;
                        }
                        break;
                    case "Cappuccino":
                        total = numOfDrinks * 1.20;
                        break;
                    case "Tea":
                        total = numOfDrinks * 0.60;
                        break;
                }
            }
            else if(sugar == "Extra")
            {
                switch (drink)
                {
                    case "Espresso":
                        total = numOfDrinks * 1.20;
                        if (numOfDrinks >= 5)
                        {
                            total -= total * 0.25;
                        }
                        break;
                    case "Cappuccino":
                        total = numOfDrinks * 1.60;
                        break;
                    case "Tea":
                        total = numOfDrinks * 0.70;
                        break;
                }
            }

            if(total > 15)
            {
                total -= total * 0.20;
            }
            Console.WriteLine($"You bought {numOfDrinks} cups of {drink} for {total:f2} lv.");
        }
    }
}
