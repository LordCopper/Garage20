using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage20.Models
{
    public class IndexViewModel
    {
        [Key]
        [Display(Name = "Registration Number")]
        public string RegNr { get; set; }

        [Display(Name = "Vehicle Type")]
        public VehicleTypes VehicleType { get; set; }

        public string Color { get; set; }

        [Display(Name = "Registration Number")]
        public DateTime ParkingTime { get; set; }

        public IndexViewModel() { }
        public IndexViewModel(ParkedVehicles pv)
        {
            VehicleType = pv.VehicleType;
            Color = pv.Color;
            ParkingTime = pv.ParkingTime;
            RegNr = pv.RegNr;
        }
    }
}