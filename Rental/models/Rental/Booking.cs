using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.models.Vehicle.Types;

namespace Rental.models.Rentals
{
    public class Booking
    {
        public int Id { get; set; }
        public int PersonalNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public IVehicleCategory VehicleCategory { get; set; }
        public DateTime RentalStart { get; set; }
        public DateTime RentalEnd { get; set; }
        public int StartMileage { get; set; }
        public int EndMileage { get; set; }
        public decimal Price { get; set; }
    }
}
