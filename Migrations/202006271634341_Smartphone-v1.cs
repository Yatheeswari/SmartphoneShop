namespace SmartphoneShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Smartphonev1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cart", "SmartphoneFeature_MobileId", "dbo.SmartphoneFeature");
            DropIndex("dbo.Cart", new[] { "SmartphoneFeature_MobileId" });
            DropTable("dbo.Cart");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        CartId = c.String(nullable: false, maxLength: 128),
                        Brand = c.String(),
                        Model = c.String(),
                        Price = c.Double(nullable: false),
                        Image = c.String(maxLength: 1024),
                        SmartphoneFeature_MobileId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CartId);
            
            CreateIndex("dbo.Cart", "SmartphoneFeature_MobileId");
            AddForeignKey("dbo.Cart", "SmartphoneFeature_MobileId", "dbo.SmartphoneFeature", "MobileId");
        }
    }
}
