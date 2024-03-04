using System;

namespace _6._Cinema_Tickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int allSeats = 0;
            string typeticket = "";
            int freeSeats = 0;
            int allTicketsForThisFilm = 0;
            int StudentsTickets = 0;
            int StandardTickets = 0;
            int KidTickets = 0;
            int allTickets = 0;
            while(name != "Finish")
            {
                allSeats = int.Parse(Console.ReadLine());
                freeSeats = allSeats;
                typeticket = Console.ReadLine();
                while (typeticket != "End")
                {
                    
                    switch (typeticket)
                    {
                        case "student":
                            StudentsTickets++;
                            allTicketsForThisFilm++;
                            break;
                        case "standard":
                            StandardTickets++;
                            allTicketsForThisFilm++;
                            break;
                        case "kid":
                            KidTickets++;
                            allTicketsForThisFilm++;
                            break;
                    }
                    
                    freeSeats--;
                    if(freeSeats <= 0)
                    {
                        break;
                    }
                    typeticket = Console.ReadLine();
                }
                Console.WriteLine($"{name} - {((allTicketsForThisFilm)/(double)allSeats)*100:f2}% full.");
                allTicketsForThisFilm = 0;
                name = Console.ReadLine();
            }
            allTickets = KidTickets + StandardTickets + StudentsTickets;
            Console.WriteLine($"Total tickets: {allTickets}");
            Console.WriteLine($"{((double)StudentsTickets / allTickets)*100:f2}% student tickets.");
            Console.WriteLine($"{((double)StandardTickets / allTickets)*100:f2}% standard tickets.");
            Console.WriteLine($"{((double)KidTickets / allTickets)*100:f2}% kids tickets.");
        }
    }
}
