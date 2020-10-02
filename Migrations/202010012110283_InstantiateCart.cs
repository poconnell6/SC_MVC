namespace SC_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InstantiateCart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cart",
                c => new
                    {
                        PrimaryKey = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PrimaryKey);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.cart");
        }
    }
}
