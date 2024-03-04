using System;
using System.Collections.Generic;
using System.Text;

namespace Booking
{
    public class Hotel
    {
        public Hotel()
        {
            Reservations = new List<Reservation>();
        }

        public List<Reservation> Reservations { get; set; }


        public void AddReservation(DateTime startDate, DateTime endDate)
        {
            foreach (var reservation in Reservations)
            {
                bool ovelap = startDate < reservation.End && endDate > reservation.Start;

                if (ovelap)
                {
                    throw new ArgumentException($"Hotel is already booked for these dates[{startDate}-{endDate}]");
                }
            }
            Reservations.Add(new Reservation(startDate, endDate));
        }
    }
}
