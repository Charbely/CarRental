using NUnit.Framework;
using Vehicle.models.Vehicle.Types;

namespace Rental.Tests
{
    [TestFixture]
    public class VehicleCategoryTests
    {
        [Test]
        public void SmallCar_CalculatePrice_ReturnsCorrectPrice()
        {
            // Arrange
            var smallCar = new SmallCar
            {
                BaseDayPrice = 40
            };
            var rentalDays = 3;
            var rentalDistance = 100;

            // Act
            var price = smallCar.CalculatePrice(rentalDays, rentalDistance);

            // Assert
            var expectedPrice = smallCar.BaseDayPrice * rentalDays;
            Assert.That(price, Is.EqualTo(expectedPrice));
        }

        [Test]
        public void CombiCar_CalculatePrice_ReturnsCorrectPrice()
        {
            // Arrange
            var combiCar = new CombiCar
            {
                BaseDayPrice = 60,
                BaseDistancePrice = 0.7m
            };
            var rentalDays = 4;
            var rentalDistance = 150;

            // Act
            var price = combiCar.CalculatePrice(rentalDays, rentalDistance);

            // Assert
            var expectedPrice = combiCar.BaseDayPrice * rentalDays * combiCar.DayPriceMultiplier +
                                combiCar.BaseDistancePrice * rentalDistance;
            Assert.That(price, Is.EqualTo(expectedPrice));
        }

        [Test]
        public void Truck_CalculatePrice_ReturnsCorrectPrice()
        {
            // Arrange
            var truck = new Truck
            {
                BaseDayPrice = 70,
                BaseDistancePrice = 0.8m
            };
            var rentalDays = 10;
            var rentalDistance = 200;

            // Act
            var price = truck.CalculatePrice(rentalDays, rentalDistance);

            // Assert
            var expectedPrice = truck.BaseDayPrice * rentalDays * truck.DayPriceMultiplier +
                                truck.BaseDistancePrice * rentalDistance * truck.DistancePriceMultiplier;
            Assert.That(price, Is.EqualTo(expectedPrice));
        }
    }
}
