namespace CodeCampInitiative.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CodeCamps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Moniker = c.String(),
                        EventDate = c.DateTime(nullable: false),
                        Length = c.Int(nullable: false),
                        Location_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .Index(t => t.Location_Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VenueName = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Address3 = c.String(),
                        CityTown = c.String(),
                        StateProvince = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Abstract = c.String(),
                        Level = c.Int(nullable: false),
                        CodeCamp_Id = c.Int(),
                        Speaker_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CodeCamps", t => t.CodeCamp_Id)
                .ForeignKey("dbo.Speakers", t => t.Speaker_Id)
                .Index(t => t.CodeCamp_Id)
                .Index(t => t.Speaker_Id);
            
            CreateTable(
                "dbo.Speakers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleName = c.String(),
                        Company = c.String(),
                        CompanyUrl = c.String(),
                        BlogUrl = c.String(),
                        Twitter = c.String(),
                        GitHub = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sessions", "Speaker_Id", "dbo.Speakers");
            DropForeignKey("dbo.Sessions", "CodeCamp_Id", "dbo.CodeCamps");
            DropForeignKey("dbo.CodeCamps", "Location_Id", "dbo.Locations");
            DropIndex("dbo.Sessions", new[] { "Speaker_Id" });
            DropIndex("dbo.Sessions", new[] { "CodeCamp_Id" });
            DropIndex("dbo.CodeCamps", new[] { "Location_Id" });
            DropTable("dbo.Speakers");
            DropTable("dbo.Sessions");
            DropTable("dbo.Locations");
            DropTable("dbo.CodeCamps");
        }
    }
}
