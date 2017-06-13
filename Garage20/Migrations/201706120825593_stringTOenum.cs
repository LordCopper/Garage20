namespace Garage20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stringTOenum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ParkedVehicles", "VehicleType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ParkedVehicles", "VehicleType", c => c.String());
        }
    }
}
