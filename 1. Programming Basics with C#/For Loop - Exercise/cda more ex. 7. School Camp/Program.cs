using System;

namespace cda_more_ex._7._School_Camp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string typeGroup = Console.ReadLine();
            int students = int.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            string sport = "";
            double price = 0;

            switch (season)
            {
                case "Winter":
                    switch (typeGroup)
                    {
                        case "boys":
                            sport = "Judo";
                            price = nights * 9.60;
                            break;
                        case "girls":
                            sport = "Gymnastics";
                            price = nights * 9.60;
                            break;
                        case "mixed":
                            sport = "Ski";
                            price = nights * 10.00;
                            break;
                    }
                    break;
                case "Spring":
                    switch (typeGroup)
                    {
                        case "boys":
                            sport = "Tennis";
                            price = nights * 7.20;
                            break;
                        case "girls":
                            sport = "Athletics";
                            price = nights * 7.20;
                            break;
                        case "mixed":
                            sport = "Cycling";
                            price = nights * 9.50;
                            break;
                    }
                    break;
                case "Summer":
                    switch (typeGroup)
                    {
                        case "boys":
                            sport = "Football";
                            price = nights * 15.00;
                            break;
                        case "girls":
                            sport = "Volleyball";
                            price = nights * 15.00;
                            break;
                        case "mixed":
                            sport = "Swimming";
                            price = nights * 20.00;
                            break;
                    }
                    break;
            }
            price = price * students;
            if(students >= 10 && students < 20)
            {
                price -= price * 0.05;
            }
            else if(students >= 20 && students < 50)
            {
                price -= price * 0.15;
            }
            else if(students >= 50)
            {
                price -= price * 0.50;
            }
            Console.WriteLine($"{sport} {price:f2} lv.");
        }
    }
}
