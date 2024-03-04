using System;

namespace _2._Oscars_week_in_cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filmName = Console.ReadLine();
            string typeOfHall = Console.ReadLine();
            int numberOfTickets = int.Parse(Console.ReadLine());
            double income = 0;
            if(typeOfHall == "normal")
            {
                switch (filmName)
                {
                    case "A Star Is Born":
                        income = numberOfTickets * 7.50;
                        break;
                    case "Bohemian Rhapsody":
                        income = numberOfTickets * 7.35;
                        break;
                    case "Green Book":
                        income = numberOfTickets * 8.15;
                        break;
                    case "The Favourite":
                        income = numberOfTickets * 8.75;
                        break;
                }
            }
            else if(typeOfHall == "luxury")
            {
                switch (filmName)
                {
                    case "A Star Is Born":
                        income = numberOfTickets * 10.50;
                        break;
                    case "Bohemian Rhapsody":
                        income = numberOfTickets * 9.45;
                        break;
                    case "Green Book":
                        income = numberOfTickets * 10.25;
                        break;
                    case "The Favourite":
                        income = numberOfTickets * 11.55;
                        break;
                }
            }
            else if(typeOfHall == "ultra luxury")
            {
                switch (filmName)
                {
                    case "A Star Is Born":
                        income = numberOfTickets * 13.50;
                        break;
                    case "Bohemian Rhapsody":
                        income = numberOfTickets * 12.75;
                        break;
                    case "Green Book":
                        income = numberOfTickets * 13.25;
                        break;
                    case "The Favourite":
                        income = numberOfTickets * 13.95;
                        break;
                }
            }
            Console.WriteLine(value: $"{filmName} -> {income:f2} lv.");
        }
    }
}
