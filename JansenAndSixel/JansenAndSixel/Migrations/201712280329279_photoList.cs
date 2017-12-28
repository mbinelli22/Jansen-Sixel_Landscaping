namespace JansenAndSixel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class photoList : DbMigration
    {
        public override void Up()
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
        
        public override void Down()
        {
            DropTable("dbo.PhotoGalleries");
        }
    }
}
