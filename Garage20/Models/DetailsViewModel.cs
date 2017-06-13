using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage20.Models
{
    public class DetailsViewModel
    {
        [Key]
        [Display(Name = "Registration Number")]
        public string RegNr { get; set; }

        [Display(Name = "Vehicle Type")]
        public VehicleTypes VehicleType { get; set; }

        public string Color { get; set; }

        [Display(Name = "Manifacturer")]
        public string Make { get; set; }

        public string Model { get; set; }

        [Display(Name = "Nr of Wheels")]
        public int NrWheels { get; set; }

        [Display(Name = "Check-in time")]
        public DateTime ParkingTime { get; set; }

        public DetailsViewModel() { }
        public DetailsViewModel(ParkedVehicles pv)
        {
            RegNr = pv.RegNr;
            Color = pv.Color;
            Make = pv.Make;
            Model = pv.Model;
            NrWheels = pv.NrWheels;
            ParkingTime = pv.ParkingTime;
            VehicleType = pv.VehicleType;
        }
    }
}