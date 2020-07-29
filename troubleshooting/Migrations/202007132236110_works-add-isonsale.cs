namespace SC_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class worksaddisonsale : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.books", "IsOnSale", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.books", "IsOnSale");
        }
    }
}
