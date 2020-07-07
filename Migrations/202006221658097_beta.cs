namespace SC_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class beta : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.contact", "txtName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.contact", "txtName", c => c.Int(nullable: false));
        }
    }
}
