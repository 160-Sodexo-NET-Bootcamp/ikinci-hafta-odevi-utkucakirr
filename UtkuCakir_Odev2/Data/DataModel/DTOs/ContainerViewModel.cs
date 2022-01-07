using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel.DTOs
{
    public class ContainerViewModel
    {
        public string ContainerName { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longtitude { get; set; }
        public long VehicleId { get; set; }
    }
}
