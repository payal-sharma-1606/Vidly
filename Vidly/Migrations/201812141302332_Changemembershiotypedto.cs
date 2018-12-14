namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changemembershiotypedto : DbMigration
    {
        public override void Up()
        {
            Sql("Drop table MembershipTypeDtoes");
        }
        
        public override void Down()
        {
        }
    }
}
