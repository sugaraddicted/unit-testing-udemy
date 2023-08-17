using NUnit.Framework;
using TestNinja.Mocking;
using System.Linq;
using Moq;
using System.Collections.Generic;
using System;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class BookingHelper_OverlappingBookingExistsTests
    {
        private Booking _existingBooking;
        private Mock<IBookingService> _service;

        [SetUp]
        public void SetUp()
        {
            _existingBooking = new Booking
            {
                Id = 2,
                ArrivalDate = ArriveOn(2023, 1, 11),
                DepartureDate = DepartOn(2023, 1, 16),
                Reference = "a",
            };

            _service = new Mock<IBookingService>();
            _service.Setup(s => s.GetActiveBookings(1)).Returns(new List<Booking>
            {
               _existingBooking
            }.AsQueryable());
        }

        [Test]
        public void BookingStartsAndFinishesBeforeAnExistingBooking_ReturnEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(_service.Object,
                 new Booking
                 {
                     Id = 1,
                     ArrivalDate = Before(_existingBooking.ArrivalDate, days: 2),
                     DepartureDate = Before(_existingBooking.ArrivalDate),
                 });
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void BookingStartsBeforeAndEndsInTheMiddleOfAnExistingBooking_ReturnExistingBookingReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(_service.Object,
                 new Booking
                 {
                     Id = 1,
                     ArrivalDate = Before(_existingBooking.ArrivalDate),
                     DepartureDate = After(_existingBooking.ArrivalDate),
                 });
            Assert.That(result, Is.EqualTo(_existingBooking.Reference));
        }

        [Test]
        public void BookingsOverlapButNewBookingIsCancelled_ReturnEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(_service.Object,
                 new Booking
                 {
                     Id = 1,
                     ArrivalDate = Before(_existingBooking.ArrivalDate),
                     DepartureDate = After(_existingBooking.ArrivalDate),
                     Status = "Cancelled"
                 });
            Assert.That(result, Is.Empty);
        }
        
        [Test]
        public void BookingStartsBeforeAndEndsAfterAnExistingBooking_ReturnExistingBookingReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(_service.Object,
                 new Booking
                 {
                     Id = 1,
                     ArrivalDate = Before(_existingBooking.ArrivalDate),
                     DepartureDate = After(_existingBooking.DepartureDate),
                 });
            Assert.That(result, Is.EqualTo(_existingBooking.Reference));
        } 

        [Test]
        public void BookingStartsAndEndsInTheMiddleOfAnExistingBooking_ReturnExistingBookingReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(_service.Object,
                 new Booking
                 {
                     Id = 1,
                     ArrivalDate = After(_existingBooking.ArrivalDate),
                     DepartureDate = Before(_existingBooking.DepartureDate),
                 });
            Assert.That(result, Is.EqualTo(_existingBooking.Reference));
        }
        
        [Test]
        public void BookingStartsInTheMiddleAndEndsAfterAnExistingBooking_ReturnExistingBookingReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(_service.Object,
                 new Booking
                 {
                     Id = 1,
                     ArrivalDate = After(_existingBooking.ArrivalDate),
                     DepartureDate = After(_existingBooking.DepartureDate),
                 });
            Assert.That(result, Is.EqualTo(_existingBooking.Reference));
        }
         
        [Test]
        public void BookingStartsAndEndsAfterAnExistingBooking_ReturnEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(_service.Object,
                 new Booking
                 {
                     Id = 1,
                     ArrivalDate = After(_existingBooking.DepartureDate),
                     DepartureDate = After(_existingBooking.DepartureDate, days: 2),
                 });
            Assert.That(result, Is.Empty);
        }

        private DateTime ArriveOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 14, 0, 0);
        }

        private DateTime DepartOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 10, 0, 0);
        }
        private DateTime Before(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(-days);
        }
        private DateTime After(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(days);
        }
    }
}
