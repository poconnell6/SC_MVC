namespace SC_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.contact",
                c => new
                    {
                        intPrimaryKey = c.Int(nullable: false, identity: true),
                        txtName = c.Int(nullable: false),
                        dteDate = c.DateTime(nullable: false),
                        txtEmail = c.String(nullable: false),
                        txtEmailConfirm = c.String(nullable: false),
                        txtSubject = c.String(nullable: false),
                        txtMessage = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.intPrimaryKey);
            
            CreateTable(
                "dbo.books",
                c => new
                    {
                        PrimaryKey = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Genre = c.String(),
                    })
                .PrimaryKey(t => t.PrimaryKey);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.books");
            DropTable("dbo.contact");
        }
    }
}
