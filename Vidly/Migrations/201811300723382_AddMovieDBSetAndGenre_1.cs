namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieDBSetAndGenre_1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(ID, Name) values (1,'Comedy')");
            Sql("INSERT INTO Genres(ID, Name) values (2,'Action')");
            Sql("INSERT INTO Genres(ID, Name) values (3,'Family')");
            Sql("INSERT INTO Genres(ID, Name) values (4,'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
