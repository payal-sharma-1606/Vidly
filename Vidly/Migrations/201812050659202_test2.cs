namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "IsSubscribedToNewsLetterMembershipTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "IsSubscribedToNewsLetterMembershipTypeId", c => c.Byte(nullable: false));
        }
    }
}
