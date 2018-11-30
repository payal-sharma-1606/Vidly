namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Id, Name) values (1,'Comedy')");
            Sql("INSERT INTO Genres(Id, Name) values (2,'Action')");
            Sql("INSERT INTO Genres(Id, Name) values (3,'Family')");
            Sql("INSERT INTO Genres(Id, Name) values (4,'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
