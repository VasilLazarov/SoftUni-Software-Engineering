using System;

namespace Cash_register_in_the_subway
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string forEndProgram = "";
            while (forEndProgram != "край")
            {
                int number = 0;
                double price = 0;
                string product = "";
                double totalPrice = 0;
                while (product != "=")
                {
                    Console.Write("Въведете продукт:");
                    product = Console.ReadLine();

                    switch (product)
                    {
                        case "билет":
                            Console.Write("Въведете брой:");
                            number = int.Parse(Console.ReadLine());
                            price = number * 1.60;
                            break;
                        case "картадн":
                            Console.Write("Въведете брой:");
                            number = int.Parse(Console.ReadLine());
                            price = number * 4.00;
                            break;
                        case "карта10":
                            Console.Write("Въведете брой:");
                            number = int.Parse(Console.ReadLine());
                            price = number * 10.60;
                            break;

                    }
                    totalPrice += price;
                    price = 0;
                }

                Console.WriteLine($"Цена: {Math.Round(totalPrice, 2):f2} leva");
                Console.Write("Пари от клиен:");
                double recievedMoney = double.Parse(Console.ReadLine());
                double resto = recievedMoney - totalPrice;
                Console.WriteLine($"Ресто {Math.Round(resto, 2):f2}");
                forEndProgram = Console.ReadLine();
                recievedMoney = 0;
                resto = 0;
                totalPrice = 0;
            }
        }
    }
}
