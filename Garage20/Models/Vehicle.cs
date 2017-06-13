using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage20.Models
{
    public class Vehicle
    {
        [Display(Name = "Registration Number")]
        [RegularExpression("([A-Za-z]{3}[0-9]{3})",ErrorMessage = "The registraintion number must follow the mold \"xxx111\"")]
        [Required]
        public string RegNr { get; set; }

        [Display(Name = "Vehicle Type")]
        [Required]
        public VehicleTypes VehicleType { get; set; }

        [Required]
        public string Color { get; set; }

        [Display(Name = "Manifacturer")]
        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Display(Name = "Nr of Wheels")]
        [Required]
        public int NrWheels { get; set; }
    }
}