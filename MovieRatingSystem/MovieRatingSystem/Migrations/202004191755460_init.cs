namespace MovieRatingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Movie_Id = c.Int(nullable: false, identity: true),
                        Movie_Name = c.String(nullable: false),
                        Movie_Type = c.String(nullable: false),
                        Movie_Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Movie_Id);
            
            CreateTable(
                "dbo.User_Rating",
                c => new
                    {
                        User_Rarting_Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        MovieName = c.String(nullable: false),
                        User_Provided_Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.User_Rarting_Id)
                .ForeignKey("dbo.SystemUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.SystemUsers",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        User_Name = c.String(nullable: false),
                        User_Password = c.String(nullable: false),
                        User_Designation = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User_Rating", "UserId", "dbo.SystemUsers");
            DropIndex("dbo.User_Rating", new[] { "UserId" });
            DropTable("dbo.SystemUsers");
            DropTable("dbo.User_Rating");
            DropTable("dbo.Movies");
        }
    }
}
