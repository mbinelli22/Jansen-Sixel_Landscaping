namespace JansenAndSixel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedRequiredField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomProjects", "TypeOfProject", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomProjects", "TypeOfProject", c => c.String(nullable: false));
        }
    }
}
