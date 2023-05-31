using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.models.Vehicle.Types
{
    public interface IVehicleCategory
    {
        public decimal BaseDistancePrice { get; set; }
        public decimal BaseDayPrice { get; set; }
        public decimal CalculatePrice(int days, int distance);
    }
}
