namespace SmartphoneShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.CartId)
                .ForeignKey("dbo.SmartphoneFeature", t => t.SmartphoneFeature_MobileId)
                .Index(t => t.SmartphoneFeature_MobileId);
            
            CreateTable(
                "dbo.SmartphoneFeature",
                c => new
                    {
                        MobileId = c.String(nullable: false, maxLength: 128),
                        Brand = c.String(),
                        Model = c.String(),
                        Rating = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        ScreenSize = c.Double(nullable: false),
                        RAM = c.Int(nullable: false),
                        InternalStorage = c.Int(nullable: false),
                        FrontCamera = c.Int(nullable: false),
                        RearCamera = c.Int(nullable: false),
                        OS = c.String(),
                        Sim = c.String(),
                        Sensor = c.String(),
                        BatteryCapacity = c.Int(nullable: false),
                        Color = c.String(),
                        Image = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.MobileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cart", "SmartphoneFeature_MobileId", "dbo.SmartphoneFeature");
            DropIndex("dbo.Cart", new[] { "SmartphoneFeature_MobileId" });
            DropTable("dbo.SmartphoneFeature");
            DropTable("dbo.Cart");
        }
    }
}
