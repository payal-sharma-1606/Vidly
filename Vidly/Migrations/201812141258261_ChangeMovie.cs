namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeMovie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypeDtoes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MembershipTypeDtoes");
        }
    }
}
