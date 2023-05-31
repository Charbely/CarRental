using System;
using System.Collections.Generic;

namespace Vehicle.models.Vehicle.Types
{
    public class SmallCar : IVehicleCategory
    {
        public decimal BaseDistancePrice { get; set; }
        public decimal BaseDayPrice { get; set; }

        public decimal CalculatePrice(int days, int distance)
        {
            return this.BaseDayPrice * days;
        }
    }
}
