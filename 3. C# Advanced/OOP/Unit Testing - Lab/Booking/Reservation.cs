using System;
using System.Collections.Generic;
using System.Text;

namespace Booking
{
    public class Reservation
    {
        public Reservation(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public DateTime Start { get; set; }



        public DateTime End { get; set; }
    }
}
