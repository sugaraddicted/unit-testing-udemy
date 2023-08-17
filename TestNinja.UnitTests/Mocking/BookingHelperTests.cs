using NUnit.Framework;
using TestNinja.Mocking;
using System.Linq;
using Moq;
using System.Collections.Generic;
using System;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class BookingHelperTests
    {
        [Test]
        public void OverlappingBookingsExist_Exists_ReturnTrue()
        {
            // Arrange
            var service = new Mock<IBookingService>();
            var booking = new Booking
            {
                Id = 1,
                ArrivalDate = DateTime.Now,
                DepartureDate = DateTime.Now
            };

            // Setup the mock service to return a list with an overlapping booking
            service.Setup(s => s.GetOtherActiveBookings(booking)).Returns(new List<Booking>
            {
                new Booking
                {
                   Id = 2,
                   ArrivalDate = DateTime.Now,
                   DepartureDate = DateTime.Now
                }
            }.AsQueryable);

            // Act
            var result = BookingHelper.OverlappingBookingsExist(service.Object, booking);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void OverlappingBookingsExist_DoesntExist_ReturnFalse()
        {
            var service = new Mock<IBookingService>();
            var booking = new Booking
            {
                Id = 1,
                ArrivalDate = DateTime.Now,
                DepartureDate = DateTime.Now
            };

            service.Setup(s => s.GetOtherActiveBookings(booking)).Returns(new List<Booking>().AsQueryable);

            var result = BookingHelper.OverlappingBookingsExist(service.Object, booking);

            Assert.That(result, Is.False);
        }
    }
}
