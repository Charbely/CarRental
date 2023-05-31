using NUnit.Framework;
using Moq;
using Rental.models.Rentals;
using Vehicle.models.Vehicle.Types;
using Rental.services;

namespace Rental.Test
{
    [TestFixture]
    public class RentalServiceTests
    {
        private RentalService _rentalService;
        private Mock<IBookingService> _bookingServiceMock;

        [SetUp]
        public void Setup()
        {
            _bookingServiceMock = new Mock<IBookingService>();
            _rentalService = new RentalService(_bookingServiceMock.Object);
        }

        [Test]
        public void RentVehicle_ValidParameters_CallsCreateBooking()
        {
            // Arrange
            var personalNumber = 123;
            var registrationNumber = "NNW860";
            var vehicleCategoryMock = new Mock<IVehicleCategory>();
            var rentalStart = DateTime.Now;
            var mileage = 10000;

            // Act
            _rentalService.RentVehicle(personalNumber, registrationNumber, vehicleCategoryMock.Object, rentalStart, mileage);

            // Assert
            _bookingServiceMock.Verify(mock => mock.CreateBooking(It.IsAny<Booking>()), Times.Once);
        }

        [Test]
        public void ReturnVehicle_BookingNotFound_ThrowsArgumentException()
        {
            // Arrange
            var bookingId = 1;
            var rentalEnd = DateTime.Now;
            var newMileage = 20000;

            _bookingServiceMock.Setup(mock => mock.GetBooking(bookingId)).Returns((Booking)null);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _rentalService.ReturnVehicle(bookingId, rentalEnd, newMileage));
        }

        [Test]
        public void ReturnVehicle_ValidBooking_ReturnsDecimalPrice()
        {
            // Arrange
            var bookingId = 1;
            var rentalEnd = new DateTime(2023, 5, 31);
            var newMileage = 20000;

            var booking = new Booking
            {
                Id = bookingId,
                RentalStart = new DateTime(2023, 5, 29),
                StartMileage = 15000,
                VehicleCategory = new Mock<IVehicleCategory>().Object
            };

            _bookingServiceMock.Setup(mock => mock.GetBooking(bookingId)).Returns(booking);

            // Act
            var price = _rentalService.ReturnVehicle(bookingId, rentalEnd, newMileage);

            // Assert
            Assert.IsInstanceOf<decimal>(price);
        }

        [Test]
        public void CalculateDays_ValidDatesWithTimeDifference_ReturnsCorrectNumberOfDays()
        {
            // Arrange
            var start = DateTime.Now;
            var end = start.AddDays(2).AddMinutes(5);

            // Act
            var actualDays = _rentalService.CalculateDays(start, end);

            // Assert
            var expectedDays = (end.Date.AddDays(1) - start.Date).Days;
            Assert.That(actualDays, Is.EqualTo(expectedDays));
        }
    }
}

//Test calculate days