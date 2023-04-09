using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    class BookingHelper_OverlappingBookingsExist_Tests
    {
        private Booking _existinBooking;
        private Mock<IBookingRepository> _repository;

        [SetUp]

        public void SetUp()
        {
            _existinBooking = new Booking
            {
                Id = 2,
                ArrivalDate = ArriveOn(2017, 1, 15),
                DepartureDate = DepartOn(2017, 1, 20),
                Reference = "a"
            };

            var repository = new Mock<IBookingRepository>();
            repository.Setup(r => r.GetActiveBookings(1)).Returns(
                new List<Booking> // with Setup we prepare data
                {
                    _existinBooking
                }.AsQueryable());
        }

        [Test]
        public void BookingStartsAndFinishedBeforeExistingBooking_ReturnEmptyString()
        {

            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(_existinBooking.ArrivalDate, days: 2),
                DepartureDate = After(_existinBooking.ArrivalDate)
            }, _repository.Object);

            Assert.That(result, Is.EqualTo("a"));
        }

        [Test]
        public void BookingStartsBeforeAndFinishedInTheMiddleOfExistingBooking_ReturnExistingBookingsReference()
        {

            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(_existinBooking.ArrivalDate, days: 2),
                DepartureDate = Before(_existinBooking.ArrivalDate)
            }, _repository.Object);

            Assert.That(result, Is.Empty);
        }

        private DateTime Before(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(-days);
        }

        private DateTime After(DateTime dateTime)
        {
            return dateTime.AddDays(1);
        }

        private DateTime ArriveOn(int year, int mont, int day)
        {
            return new DateTime(year, mont, day, 14, 0, 0);
        }

        private DateTime DepartOn(int year, int mont, int day)
        {
            return new DateTime(year, mont, day, 10, 0, 0);
        }

    }
}
