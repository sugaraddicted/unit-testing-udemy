using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        [TestCase(15)]
        [TestCase(30)]
        [TestCase(45)]
        public void GetOutput_InputIsDivisibleBy3And5_ReturnsFizzBuzz(int input)
        {
            var result = FizzBuzz.GetOutput(input);

            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        [TestCase(3)]
        [TestCase(9)]
        [TestCase(12)]
        public void GetOutput_InputIsDivisibleBy3_ReturnsFizz(int input)
        {
            var result = FizzBuzz.GetOutput(input);

            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(20)]
        public void GetOutput_InputIsDivisibleBy5_ReturnsBuzz(int input)
        {
            var result = FizzBuzz.GetOutput(input);

            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [Test]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(11)]
        public void GetOutput_InputIsNotDivisibleBy3or5_ReturnsInput(int input)
        {
            var result = FizzBuzz.GetOutput(input);

            Assert.That(result, Is.EqualTo(input.ToString()));
        }
    }
}
