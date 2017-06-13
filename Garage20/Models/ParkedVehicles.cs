using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage20.Models
{
    public class ParkedVehicles
    {
        public int Id { get; set; }
        public VehicleTypes VehicleType { get; set; }
        public string RegNr { get; set; }
        public string Color { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int NrWheels { get; set; }
        public DateTime ParkingTime { get; set; }

        public ParkedVehicles() { }
        public ParkedVehicles(Vehicle vehicle)
        {
            RegNr = vehicle.RegNr;
            Color = vehicle.Color;
            Make = vehicle.Make;
            Model = vehicle.Model;
            VehicleType = vehicle.VehicleType;
            NrWheels = vehicle.NrWheels;
            ParkingTime = DateTime.Now;
        }
    }
}