using Rental.models.Rentals;
using Vehicle.models.Vehicle.Types;

namespace Rental.services
{
    public interface IRentalService
    {

    }

    public class RentalService : IRentalService
    {
        private readonly IBookingService _bookingService;

        public RentalService(IBookingService bookingService)
        {
            _bookingService = bookingService ?? throw new ArgumentNullException(nameof(bookingService));
        }

        public int RentVehicle(int personalNumber, string registrationNumber, IVehicleCategory vehicleCategory, DateTime rentalStart, int milage)
        {
            var booking = new Booking
            {
                Id = 1,
                PersonalNumber = personalNumber,
                RegistrationNumber = registrationNumber,
                VehicleCategory = vehicleCategory,
                RentalStart = rentalStart,
                StartMileage = milage
            };

            //Create booking
            var bookingId = _bookingService.CreateBooking(booking);

            return bookingId;
        }

        public decimal ReturnVehicle(int bookingId, DateTime rentalEnd, int newMilage)
        {
            //Get booking
            var booking = _bookingService.GetBooking(bookingId);

            if (booking == null)
            {
                throw new ArgumentException("There is no booking with this Id");
            }

            var rentalDays = CalculateDays(booking.RentalStart, rentalEnd);
            var rentalDistance = booking.StartMileage - newMilage;
            var price = booking.VehicleCategory.CalculatePrice(rentalDays, rentalDistance);

            booking.RentalEnd = rentalEnd;
            booking.EndMileage = newMilage;
            booking.Price = price;

            //Save booking

            return price;
        }

        public int CalculateDays(DateTime start, DateTime end)
        {
            TimeSpan rentalDuration = end.Date.AddDays(1) - start.Date;
            return (int)rentalDuration.TotalDays;
        }
    }
}
