namespace JansenAndSixel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedEmailAndPhoneNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomProjects", "PhoneNumber", c => c.String());
            AddColumn("dbo.CustomProjects", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomProjects", "Email");
            DropColumn("dbo.CustomProjects", "PhoneNumber");
        }
    }
}
