namespace JansenAndSixel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customProjectchangebooltostring : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomProjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TypeOfProject = c.String(nullable: false),
                        TypeOfLandscapeProject = c.String(),
                        TypeOfHardscapeProject = c.String(),
                        TypeOfMaterial = c.String(),
                        QuantityOfMaterial = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomProjects");
        }
    }
}
