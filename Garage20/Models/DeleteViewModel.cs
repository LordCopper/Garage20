using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage20.Models
{
    public class DeleteViewModel
    {
        [Key]
        [Display(Name = "Registration Number")]
        public string RegNr { get; set; }
        [Display(Name = "Vehicle Type")]
        public VehicleTypes VehicleType { get; set; }
        [Display(Name = "Check-in time")]
        public DateTime ParkingTime { get; set; }
        [Display(Name = "Price so far")]
        public int PriceSoFar { get; set; }

        public DeleteViewModel() { }
        public DeleteViewModel(ParkedVehicles pv)
        {
            RegNr = pv.RegNr;
            VehicleType = pv.VehicleType;
            ParkingTime = pv.ParkingTime;
            PriceSoFar = Util.GetTotalMinutes(pv.ParkingTime) * 2;
        }
    }
}