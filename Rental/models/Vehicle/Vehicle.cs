using Vehicle.models.Vehicle.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.models.Vehicle
{
    interface Vehicle
    {
        string RegistrationNumber { get; set; }
        string Brand { get; set; }
        string Model { get; set; }
        DateTime YearModel { get; set; }
        int Mileage { get; set; }
        IVehicleCategory VehicleCategory { get; set; }
    }
}