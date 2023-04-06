using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;


namespace TestNinja.UnitTests
{
    [TestFixture]
    internal class FizzBuzzTests
    {
        private FizzBuzz _fizzBuzz;

        [SetUp]
        public void SetUp()
        {
            _fizzBuzz = new FizzBuzz();
        }

        [Test]
        public void GetOutput_NumberDivisibleByThreeAndFive_ReturnFizzBuzz()
        {
            Assert.That(FizzBuzz.GetOutput(15), Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void GetOutput_NumberDivisibleByThreeOnly_ReturnFizz()
        {
            Assert.That(FizzBuzz.GetOutput(3), Is.EqualTo("Fizz"));
        }

        [Test]
        public void GetOutput_NumberDivisibleByFiveOnly_ReturnFizz()
        {
            Assert.That(FizzBuzz.GetOutput(10), Is.EqualTo("Buzz"));
        }

        [Test]
        public void GetOutput_NumberisNotDivisibleByThreeAndFive_ReturnFizzBuzz()
        {
            Assert.That(FizzBuzz.GetOutput(2), Is.Not.EqualTo("FizzBuzz"));
        }

        /*[Test]
        public void GetOutput_NumberDivisibleByThreeAndFive_ReturnFizzBuzz()
        {
            Assert.That(FizzBuzz.GetOutput(15), Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void GetOutput_NumberDivisibleByThreeOnly_ReturnFizz()
        {
            Assert.That(FizzBuzz.GetOutput(6), Is.EqualTo("Fizz"));
        }

        [Test]
        public void GetOutput_NumberDivisibleByFiveOnly_ReturnFizzBuzz()
        {
            Assert.That(FizzBuzz.GetOutput(10), Is.EqualTo("Buzz"));
        }

        [Test]
        public void GetOutput_NumberNotDivisibleByThreeOrFive_ReturnNumber()
        {
            Assert.That(FizzBuzz.GetOutput(1), Is.EqualTo(1.ToString()));
        }

        [Test]
        public void GetOutput_NumberIsZero_ReturnFizzBuzz()
        {
            Assert.That(FizzBuzz.GetOutput(0), Is.EqualTo("FizzBuzz"));
        }*/
    }
}
