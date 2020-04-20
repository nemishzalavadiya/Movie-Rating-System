namespace MovieRatingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Movie_Rating", c => c.Double(nullable: false));
            AlterColumn("dbo.User_Rating", "User_Provided_Rating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User_Rating", "User_Provided_Rating", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "Movie_Rating", c => c.Int(nullable: false));
        }
    }
}
