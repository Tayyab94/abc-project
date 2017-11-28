namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Advertisement_Relates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advertisements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 300, unicode: false),
                        Description = c.String(maxLength: 8000, unicode: false),
                        Price = c.Single(nullable: false),
                        PostOn = c.DateTime(nullable: false),
                        ValidUpTo = c.DateTime(nullable: false),
                        City_Id = c.Int(nullable: false),
                        Status_Id = c.Int(nullable: false),
                        SubCatagory_Id = c.Int(nullable: false),
                        Type_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id, cascadeDelete: true)
                .ForeignKey("dbo.AdvertisementStatus", t => t.Status_Id, cascadeDelete: true)
                .ForeignKey("dbo.SubCatagories", t => t.SubCatagory_Id, cascadeDelete: true)
                .ForeignKey("dbo.AdvertisementTypes", t => t.Type_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.City_Id)
                .Index(t => t.Status_Id)
                .Index(t => t.SubCatagory_Id)
                .Index(t => t.Type_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AdvertisementImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(nullable: false, maxLength: 300, unicode: false),
                        Caption = c.String(maxLength: 100, unicode: false),
                        Priority = c.Int(nullable: false),
                        Advertisement_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Advertisements", t => t.Advertisement_Id)
                .Index(t => t.Advertisement_Id);
            
            CreateTable(
                "dbo.AdvertisementStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AdvertisementTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Advertisements", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Advertisements", "Type_Id", "dbo.AdvertisementTypes");
            DropForeignKey("dbo.Advertisements", "SubCatagory_Id", "dbo.SubCatagories");
            DropForeignKey("dbo.Advertisements", "Status_Id", "dbo.AdvertisementStatus");
            DropForeignKey("dbo.AdvertisementImages", "Advertisement_Id", "dbo.Advertisements");
            DropForeignKey("dbo.Advertisements", "City_Id", "dbo.Cities");
            DropIndex("dbo.AdvertisementImages", new[] { "Advertisement_Id" });
            DropIndex("dbo.Advertisements", new[] { "User_Id" });
            DropIndex("dbo.Advertisements", new[] { "Type_Id" });
            DropIndex("dbo.Advertisements", new[] { "SubCatagory_Id" });
            DropIndex("dbo.Advertisements", new[] { "Status_Id" });
            DropIndex("dbo.Advertisements", new[] { "City_Id" });
            DropTable("dbo.AdvertisementTypes");
            DropTable("dbo.AdvertisementStatus");
            DropTable("dbo.AdvertisementImages");
            DropTable("dbo.Advertisements");
        }
    }
}
