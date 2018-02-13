namespace JansenAndSixel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomProject : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.PhotoGalleries");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PhotoGalleries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
