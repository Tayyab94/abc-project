namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tayyab : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Address_Id", c => c.Int());
            CreateIndex("dbo.Users", "Address_Id");
            AddForeignKey("dbo.Users", "Address_Id", "dbo.Addresses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Users", new[] { "Address_Id" });
            DropColumn("dbo.Users", "Address_Id");
        }
    }
}
