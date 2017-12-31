namespace JansenAndSixel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class phonenumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "PhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "PhoneNumber");
        }
    }
}
