namespace Garage20.Migrations
{
    using Garage20.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage20.DataAccess.GarageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Garage20.DataAccess.GarageContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.ParkedVehicle.AddOrUpdate(v => v.RegNr,
                new ParkedVehicles { RegNr = "Air001", VehicleType = VehicleTypes.Airplane, Color = "White", Make = "Boing", Model = "A1", NrWheels = 12, ParkingTime = DateTime.Now },
                new ParkedVehicles { RegNr = "Car001", VehicleType = VehicleTypes.Car, Color = "Black", Make = "Ferrari", Model = "Extender", NrWheels = 4, ParkingTime = DateTime.Now },
                new ParkedVehicles { RegNr = "Mch001", VehicleType = VehicleTypes.Motorcyckle, Color = "Grey", Make = "HD", Model = "Hammer", NrWheels = 3, ParkingTime = DateTime.Now },
                new ParkedVehicles { RegNr = "Bot001", VehicleType = VehicleTypes.Boat, Color = "Blue", Make = "Sub", Model = "Meatball", NrWheels = 0, ParkingTime = DateTime.Now },
                new ParkedVehicles { RegNr = "Bus001", VehicleType = VehicleTypes.Bus, Color = "Red", Make = "London", Model = "Double Decker", NrWheels = 6, ParkingTime = DateTime.Now });

        }
    }
}
