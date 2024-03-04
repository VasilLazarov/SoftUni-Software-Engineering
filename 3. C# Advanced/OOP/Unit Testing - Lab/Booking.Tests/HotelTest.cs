using Booking;
using NuGet.Frameworks;
using NUnit.Framework;
using System;

namespace BookingTests
{
    [TestFixture]
    public class HotelTest
    {
        private Hotel hotel;
        private DateTime startDate;
        private DateTime endDate;
        [SetUp]
        public void Setup()
        {
            hotel = new Hotel();

            startDate = new DateTime(2022, 11, 1);
            endDate = new DateTime(2022, 11, 5);
            hotel.AddReservation(startDate, endDate);
        }
        [Test]
        public void BookingWhenHotelAvailabelShouldWork()
        {
            Assert.That(hotel.Reservations.Count, Is.EqualTo(1), "Reservation has not beed added correctly!");
            Assert.That(hotel.Reservations[0].Start, Is.EqualTo(startDate));
            Assert.That(hotel.Reservations[0].End, Is.EqualTo(endDate));
        }

        [Test]
        public void MultipleBookingsWhenHotelAvailabelShouldWork()
        {
            startDate = new DateTime(2022, 11, 1);
            endDate = new DateTime(2022, 11, 5);
            hotel.AddReservation(startDate.AddDays(10), endDate.AddDays(10));

            hotel.AddReservation(startDate.AddDays(25), endDate.AddDays(25));

            hotel.AddReservation(startDate.AddDays(50), endDate.AddDays(50));

            Assert.That(hotel.Reservations.Count, Is.EqualTo(4), "Reservation has not beed added correctly!");
        }

        [Test]
        public void TryingToAddOverlappingReservationShouldThrow()
        {

            startDate = new DateTime(2022, 11, 4);
            endDate = new DateTime(2022, 11, 7);

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.AddReservation(startDate, endDate);
            });

            startDate = new DateTime(2022, 10, 28);
            endDate = new DateTime(2022, 11, 2);

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.AddReservation(startDate, endDate);
            });

            startDate = new DateTime(2022, 11, 2);
            endDate = new DateTime(2022, 11, 4);

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.AddReservation(startDate, endDate);
            });

            startDate = new DateTime(2022, 10, 30);
            endDate = new DateTime(2022, 11, 10);

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.AddReservation(startDate, endDate);
            });


        }
    }
}