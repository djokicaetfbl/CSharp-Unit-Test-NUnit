﻿using TestNinja.Fundamentals;
using NUnit.Framework;
using System.Linq;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class MathTests
    {
        private Math _math;

        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        [Ignore("Zato sto trenutno tako zelim, kasnije cu se vratiti na ovaj test")]
        public void Add_WhenCalled_ReturnSumOfArguments()
        {
            var result = _math.Add(1, 2);
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Max_FirstArgumentIsGreater_ReturnFirstArgument()
        {
            var result = _math.Max(2, 1);
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Max_SecondArgumentIsGreater_ReturnSecondArgument()
        {
            var result = _math.Max(1, 2);
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Max_ArgumentsAreEqual_ReturnTheSameArgument()
        {
            var result = _math.Max(1, 1);
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        [TestCase(2,1, 2)]
        [TestCase(1,2, 2)]
        [TestCase(1,1, 1)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetOddNumbers_LimitIsGreatherThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);

            /*Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count(), Is.EqualTo(3));

            Assert.That(result, Does.Contain(1));
            Assert.That(result, Does.Contain(3));
            Assert.That(result, Does.Contain(5));*/

            Assert.That(result, Is.EquivalentTo(new [] {1, 3, 5}));

            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.Unique);
        }

        /* private Math _math;
         // SetUp
         [SetUp]
         public void SetUp()
         {
             _math = new Math();
         }


         [Test]
         public void Add_WhenCalled_ReturnTheSumOfArguments()
         {
             var result = _math.Add(1, 2);

             Assert.That(result, Is.EqualTo(3));
         }

         [Test]
         [TestCase(2, 1, 2)]
         [TestCase(1, 2, 2)]
         [TestCase(1, 1, 1)]
         public void Max_FirstArgumentIsGreater_ReturnTheGreaterArgument(int a, int b, int expectedResult)
         {
             var result = _math.Max(a, b);

             Assert.That(result, Is.EqualTo(expectedResult));
         }

         [Test]
         public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
         {
             var result = _math.GetOddNumbers(5);

             //Assert.That(result, Is.Not.Empty);
             //Assert.That(result.Count(), Is.EqualTo(3));

             //Assert.That(result, Does.Contain(1));
             //Assert.That(result, Does.Contain(3));
             //Assert.That(result, Does.Contain(5));

             Assert.That(result, Is.EquivalentTo(new[] {1, 3, 5}));

             //Assert.That(result, Is.Ordered);
             //Assert.That(result, Is.Unique);
         }*/
    }
}
