using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {

        [Test]
        [TestCase(-3)]
        [TestCase(-500)]
        [TestCase(-40)]
        [TestCase(600)]
        [TestCase(500)]
        [TestCase(400)]
        public void CalculateDemeritPoints_SpeedIsOutOfRange_ThrowsArgumentOutOfRangeException(int speed)
        {
            var calculator = new DemeritPointsCalculator();

            Assert.That(() => calculator.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(64, 0)]
        [TestCase(65, 0)]
        [TestCase(65, 0)]
        [TestCase(66, 0)]
        [TestCase(70, 1)]
        [TestCase(75, 2)]
        public void CalculateDemeritPoints_WhenCalled_ReturnsDemeritPoints(int speed, int expected)
        {
            var calculator = new DemeritPointsCalculator();

            var result = calculator.CalculateDemeritPoints(speed);


            Assert.That(result, Is.EqualTo(expected));
        }

    }
}
