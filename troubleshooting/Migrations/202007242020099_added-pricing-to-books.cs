namespace SC_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpricingtobooks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.books", "Price", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("dbo.books", "PercentDiscountedTo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.books", "PercentDiscountedTo");
            DropColumn("dbo.books", "Price");
        }
    }
}
