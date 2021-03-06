namespace JansenAndSixel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pendingChanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        ZipCode = c.String(nullable: false),
                        Date = c.String(nullable: false),
                        Time = c.String(nullable: false),
                        ProjectType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Appointments");
        }
    }
}
