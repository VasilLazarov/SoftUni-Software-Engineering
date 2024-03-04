using System;

namespace _03._Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfPeople = int.Parse(Console.ReadLine());
            string typeGroup = Console.ReadLine();
            string day = Console.ReadLine();
            double price = 0;

            switch (typeGroup)
            {
                case "Students":
                    switch (day)
                    {
                        case "Friday":
                            price = countOfPeople * 8.45;
                            break;
                        case "Saturday":
                            price = countOfPeople * 9.80;
                            break;
                        case "Sunday":
                            price = countOfPeople * 10.46;
                            break;
                    }
                    if(countOfPeople >= 30)
                    {
                        price -= price * 0.15;
                    }
                    break;
                case "Business":
                    switch (day)
                    {
                        case "Friday":
                            if (countOfPeople >= 100)
                            {
                                countOfPeople -= 10;
                            }
                            price = countOfPeople * 10.90;
                            break;
                        case "Saturday":
                            if (countOfPeople >= 100)
                            {
                                countOfPeople -= 10;
                            }
                            price = countOfPeople * 15.60;
                            break;
                        case "Sunday":
                            if (countOfPeople >= 100)
                            {
                                countOfPeople -= 10;
                            }
                            price = countOfPeople * 16;
                            break;
                    }
                    break;
                case "Regular":
                    switch (day)
                    {
                        case "Friday":
                            price = countOfPeople * 15;
                            break;
                        case "Saturday":
                            price = countOfPeople * 20;
                            break;
                        case "Sunday":
                            price = countOfPeople * 22.50;
                            break;
                    }
                    if (countOfPeople >= 10 && countOfPeople <= 20)
                    {
                        price -= price * 0.05;
                    }
                    break;
            }
            Console.WriteLine($"Total price: {price:f2}");
        }
    }
}
