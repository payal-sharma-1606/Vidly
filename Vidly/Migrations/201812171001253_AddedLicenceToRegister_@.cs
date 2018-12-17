namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLicenceToRegister_ : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DrivingLicenseNo", c => c.String(nullable: false));
            DropColumn("dbo.AspNetUsers", "DrivingLicense");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "DrivingLicense", c => c.String(nullable: false));
            DropColumn("dbo.AspNetUsers", "DrivingLicenseNo");
        }
    }
}
