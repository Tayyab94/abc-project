namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _whatever_the_fuck_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catagories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubCatagories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Catagory_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Catagories", t => t.Catagory_Id, cascadeDelete: true)
                .Index(t => t.Catagory_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(maxLength: 50, unicode: false),
                        loginId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(nullable: false, maxLength: 20, unicode: false),
                        SecurityQuestion = c.String(maxLength: 255, unicode: false),
                        SecurityQAnswet = c.String(maxLength: 255, unicode: false),
                        ContactNumber = c.String(nullable: false, maxLength: 20, unicode: false),
                        Email = c.String(maxLength: 250, unicode: false),
                        ImageURL = c.String(maxLength: 260, unicode: false),
                        DOB = c.DateTime(),
                        IsActive = c.Boolean(),
                        City_Id = c.Int(),
                        Role_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .Index(t => t.City_Id)
                .Index(t => t.Role_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Users", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.SubCatagories", "Catagory_Id", "dbo.Catagories");
            DropIndex("dbo.Users", new[] { "Role_Id" });
            DropIndex("dbo.Users", new[] { "City_Id" });
            DropIndex("dbo.SubCatagories", new[] { "Catagory_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.SubCatagories");
            DropTable("dbo.Roles");
            DropTable("dbo.Catagories");
        }
    }
}
