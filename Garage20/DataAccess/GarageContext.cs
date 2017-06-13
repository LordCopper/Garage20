using Garage20.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Garage20.DataAccess
{
    public class GarageContext : DbContext
    {
        public GarageContext():base("GarageDb")
        {
        }
        public DbSet<ParkedVehicles> ParkedVehicle { get; set; }
    }
}