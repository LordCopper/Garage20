using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage20.Models
{
    public class Receit
    {
        [Display(Name = "Vehicle Type")]
        public VehicleTypes VehicleType { get; set; }

        [Display(Name = "Registration Number")]
        public string RegNr { get; set; }

        public string Color { get; set; }
    
        [Display(Name = "Manifacturer")]
        public string Make { get; set; }

        public string Model { get; set; }

        [Display(Name = "Nr of Wheels")]
        public int NrWheels { get; set; }

        [Display(Name = "Check-in time")]
        public DateTime CheckInTime { get; set; }

        [Display(Name = "Check-out time")]
        public DateTime CheckOutTime { get; set; }
        
        public int Price { get; set; }

        [Display(Name = "Total Time Parked")]
        public int TotalTimeParked { get; set; }

        public Receit() { }
        public Receit(ParkedVehicles pv)
        {
            RegNr = pv.RegNr;
            Color = pv.Color;
            NrWheels = pv.NrWheels;
            Make = pv.Make;
            Model = pv.Model;
            VehicleType = pv.VehicleType;
            CheckInTime = pv.ParkingTime;
            CheckOutTime = DateTime.Now;
            TotalTimeParked = Util.GetTotalMinutes(pv.ParkingTime);
            Price = TotalTimeParked * 2;
        }
    }
}