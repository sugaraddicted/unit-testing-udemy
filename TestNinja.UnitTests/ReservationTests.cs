﻿using TestNinja.Fundamentals;
using NUnit.Framework;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            //Arrange
            var reservation = new Reservation();

            //Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });
            
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_MadeByUser_ReturnsTrue()
        {
            //Arrange
            var user = new User { IsAdmin = false };
            var reservation = new Reservation() { MadeBy = user};

            //Act
            var result = reservation.CanBeCancelledBy(user);

            //Assert
            Assert.IsTrue(result);
        }
        
        [Test]
        public void CanBeCancelledBy_MadeNotByUserIsNotAdmin_ReturnsFalse()
        {
            //Arrange
            var user = new User { IsAdmin = false };
            var reservation = new Reservation();

            //Act
            var result = reservation.CanBeCancelledBy(user);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
