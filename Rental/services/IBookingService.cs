using Rental.models.Rentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental.services
{
    public interface IBookingService
    {
        int CreateBooking(Booking booking);
        Booking GetBooking(int id);
    }

    public class BookingService : IBookingService
    {
        public int CreateBooking(Booking booking)
        {
            return 0;
        }

        public Booking GetBooking(int Id)
        {
            return new Booking();
        }
    }
}
