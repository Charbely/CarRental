using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.models.Vehicle.Types
{
    public class Truck : IVehicleCategory
    {
        public decimal BaseDistancePrice { get; set; }
        public decimal BaseDayPrice { get; set; }
        public decimal DayPriceMultiplier { get; } = 1.5m;
        public decimal DistancePriceMultiplier { get; } = 1.5m;

        public decimal CalculatePrice(int days, int distance)
        {
            return this.BaseDayPrice * days * this.DayPriceMultiplier + this.BaseDistancePrice * distance * this.DistancePriceMultiplier;
        }
    }
}
