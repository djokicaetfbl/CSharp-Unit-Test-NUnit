using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _demeritPointsCalculator;

        [SetUp]
        public void SetUp()
        {
            _demeritPointsCalculator = new DemeritPointsCalculator();
        }

        [Test]
        [TestCase(-2)]
        [TestCase(700)]
        public void CalculateDemeritPoints_SpeedIsOutOfRange_ThrowArgumentOutOfRangeException(int speed)
        {
            /*var result = _demeritPointsCalculator.CalculateDemeritPoints(speed);
            Assert.That(result, Throws.Exception.TypeOf<ArgumentOutOfRangeException>());*/
            Assert.That(() => _demeritPointsCalculator.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(64, 0)]
        [TestCase(70,1)]
        [TestCase(78, 15)]
        public void CalculateDemeritPoints_WhenCalled_ReturnDemeritPoints(int speed, int expectedResult)
        {
            var result = _demeritPointsCalculator.CalculateDemeritPoints(speed);
            Assert.That(result, Is.EqualTo(expectedResult));

        }

        /*[Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedIsOutOfRange_ThrowArgumentOutOfRangeException(int speed)
        {
            var demeritPointsCalculator = new DemeritPointsCalculator();

            Assert.That(() => demeritPointsCalculator.CalculateDemeritPoints(speed), 
                Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(64, 0)]
        [TestCase(65, 0)]
        [TestCase(70, 1)]
        [TestCase(75, 2)]
        public void CalculateDemeritPoints_WhenCalled_ReturnDemeritPoints(int speed, int expectedResult)
        {
            var demeritPointsCalculator = new DemeritPointsCalculator();

            var points = demeritPointsCalculator.CalculateDemeritPoints(speed);

            Assert.That(points, Is.EqualTo(expectedResult));
        }*/
    }
}
