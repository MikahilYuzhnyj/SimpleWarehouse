namespace J1.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _09_10_2017_00 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Buyers", "DateCreated");
            DropColumn("dbo.Buyers", "DateUpdated");
            DropColumn("dbo.Buyers", "CreatedUserId");
            DropColumn("dbo.Buyers", "UpdatedUserId");
            DropColumn("dbo.ProductAlternateCodes", "DateCreated");
            DropColumn("dbo.ProductAlternateCodes", "DateUpdated");
            DropColumn("dbo.ProductAlternateCodes", "CreatedUserId");
            DropColumn("dbo.ProductAlternateCodes", "UpdatedUserId");
            DropColumn("dbo.Products", "DateCreated");
            DropColumn("dbo.Products", "DateUpdated");
            DropColumn("dbo.Products", "CreatedUserId");
            DropColumn("dbo.Products", "UpdatedUserId");
            DropColumn("dbo.ProductAlternateSkus", "DateCreated");
            DropColumn("dbo.ProductAlternateSkus", "DateUpdated");
            DropColumn("dbo.ProductAlternateSkus", "CreatedUserId");
            DropColumn("dbo.ProductAlternateSkus", "UpdatedUserId");
            DropColumn("dbo.ProductTags", "DateCreated");
            DropColumn("dbo.ProductTags", "DateUpdated");
            DropColumn("dbo.ProductTags", "CreatedUserId");
            DropColumn("dbo.ProductTags", "UpdatedUserId");
            DropColumn("dbo.Tags", "DateCreated");
            DropColumn("dbo.Tags", "DateUpdated");
            DropColumn("dbo.Tags", "CreatedUserId");
            DropColumn("dbo.Tags", "UpdatedUserId");
            DropColumn("dbo.SaleItems", "DateCreated");
            DropColumn("dbo.SaleItems", "DateUpdated");
            DropColumn("dbo.SaleItems", "CreatedUserId");
            DropColumn("dbo.SaleItems", "UpdatedUserId");
            DropColumn("dbo.Sales", "DateCreated");
            DropColumn("dbo.Sales", "DateUpdated");
            DropColumn("dbo.Sales", "CreatedUserId");
            DropColumn("dbo.Sales", "UpdatedUserId");
            DropColumn("dbo.SaleShipments", "DateCreated");
            DropColumn("dbo.SaleShipments", "DateUpdated");
            DropColumn("dbo.SaleShipments", "CreatedUserId");
            DropColumn("dbo.SaleShipments", "UpdatedUserId");
            DropColumn("dbo.Tenants", "DateCreated");
            DropColumn("dbo.Tenants", "DateUpdated");
            DropColumn("dbo.Tenants", "CreatedUserId");
            DropColumn("dbo.Tenants", "UpdatedUserId");
            DropColumn("dbo.Users", "DateCreated");
            DropColumn("dbo.Users", "DateUpdated");
            DropColumn("dbo.Users", "CreatedUserId");
            DropColumn("dbo.Users", "UpdatedUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "UpdatedUserId", c => c.Long(nullable: false));
            AddColumn("dbo.Users", "CreatedUserId", c => c.Long(nullable: false));
            AddColumn("dbo.Users", "DateUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tenants", "UpdatedUserId", c => c.Long(nullable: false));
            AddColumn("dbo.Tenants", "CreatedUserId", c => c.Long(nullable: false));
            AddColumn("dbo.Tenants", "DateUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tenants", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.SaleShipments", "UpdatedUserId", c => c.Long(nullable: false));
            AddColumn("dbo.SaleShipments", "CreatedUserId", c => c.Long(nullable: false));
            AddColumn("dbo.SaleShipments", "DateUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.SaleShipments", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sales", "UpdatedUserId", c => c.Long(nullable: false));
            AddColumn("dbo.Sales", "CreatedUserId", c => c.Long(nullable: false));
            AddColumn("dbo.Sales", "DateUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sales", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.SaleItems", "UpdatedUserId", c => c.Long(nullable: false));
            AddColumn("dbo.SaleItems", "CreatedUserId", c => c.Long(nullable: false));
            AddColumn("dbo.SaleItems", "DateUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.SaleItems", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tags", "UpdatedUserId", c => c.Long(nullable: false));
            AddColumn("dbo.Tags", "CreatedUserId", c => c.Long(nullable: false));
            AddColumn("dbo.Tags", "DateUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tags", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProductTags", "UpdatedUserId", c => c.Long(nullable: false));
            AddColumn("dbo.ProductTags", "CreatedUserId", c => c.Long(nullable: false));
            AddColumn("dbo.ProductTags", "DateUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProductTags", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProductAlternateSkus", "UpdatedUserId", c => c.Long(nullable: false));
            AddColumn("dbo.ProductAlternateSkus", "CreatedUserId", c => c.Long(nullable: false));
            AddColumn("dbo.ProductAlternateSkus", "DateUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProductAlternateSkus", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "UpdatedUserId", c => c.Long(nullable: false));
            AddColumn("dbo.Products", "CreatedUserId", c => c.Long(nullable: false));
            AddColumn("dbo.Products", "DateUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProductAlternateCodes", "UpdatedUserId", c => c.Long(nullable: false));
            AddColumn("dbo.ProductAlternateCodes", "CreatedUserId", c => c.Long(nullable: false));
            AddColumn("dbo.ProductAlternateCodes", "DateUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProductAlternateCodes", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Buyers", "UpdatedUserId", c => c.Long(nullable: false));
            AddColumn("dbo.Buyers", "CreatedUserId", c => c.Long(nullable: false));
            AddColumn("dbo.Buyers", "DateUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Buyers", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
