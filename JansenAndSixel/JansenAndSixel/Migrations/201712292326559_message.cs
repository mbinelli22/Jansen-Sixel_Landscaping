namespace JansenAndSixel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class message : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Message", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "Message");
        }
    }
}
