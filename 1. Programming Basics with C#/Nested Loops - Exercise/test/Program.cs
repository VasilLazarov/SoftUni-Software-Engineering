using System;

namespace _06._Cinema_Tickets
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string nameOfMovie = Console.ReadLine();
            int allSeats = 0;
            string typeTicket = "";
            int freeSeats = 0;



            int studentsTicket = 0;
            int standartTicket = 0;
            int kidTicket = 0;
            int totalBoughtTickets = 0;
            int totalForMovie = 0;
            while (nameOfMovie != "Finish")
            {
                allSeats = int.Parse(Console.ReadLine());
                freeSeats = allSeats;
                typeTicket = Console.ReadLine();

                while (typeTicket != "End")
                {
                    switch (typeTicket)
                    {
                        case "student":
                            studentsTicket++;
                            totalForMovie++;
                            break;
                        case "standard":
                            standartTicket++;
                            totalForMovie++;
                            break;
                        case "kid":
                            kidTicket++;
                            totalForMovie++;
                            break;
                    }
                    freeSeats--;
                    if (freeSeats <= 0)
                    {
                        break;
                    }
                    typeTicket = Console.ReadLine();

                }
                Console.WriteLine($"{nameOfMovie} - {((double)totalForMovie / allSeats) * 100:F2}% full.");
                totalForMovie = 0;
                nameOfMovie = Console.ReadLine();
            }
            totalBoughtTickets = studentsTicket + standartTicket + kidTicket;
            Console.WriteLine($"Total tickets: {totalBoughtTickets}");
            Console.WriteLine($"{((double)studentsTicket / totalBoughtTickets) * 100:F2}% student tickets.");
            Console.WriteLine($"{((double)standartTicket / totalBoughtTickets) * 100:F2}% standard tickets.");
            Console.WriteLine($"{((double)kidTicket / totalBoughtTickets) * 100:F2}% kids tickets.");








        }
    }
}
