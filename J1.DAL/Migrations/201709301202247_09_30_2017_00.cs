namespace J1.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _09_30_2017_00 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Classifications",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KitAlternateCodes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        KitId = c.Long(nullable: false),
                        Value = c.String(nullable: false, maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kits", t => t.KitId, cascadeDelete: true)
                .Index(t => t.KitId);
            
            CreateTable(
                "dbo.Kits",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Sku = c.String(nullable: false, maxLength: 100),
                        Code = c.String(nullable: false, maxLength: 100),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Weight = c.Int(nullable: false),
                        SizeL = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SizeH = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SizeW = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RetailPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KitAlternateSkus",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        KitId = c.Long(nullable: false),
                        Value = c.String(nullable: false, maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kits", t => t.KitId, cascadeDelete: true)
                .Index(t => t.KitId);
            
            CreateTable(
                "dbo.KitItems",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        KitId = c.Long(nullable: false),
                        ProductId = c.Long(nullable: false),
                        Quantity = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kits", t => t.KitId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.KitId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KitTags",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        KitId = c.Long(nullable: false),
                        TagId = c.Long(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kits", t => t.KitId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.KitId)
                .Index(t => t.TagId);
            
            AddColumn("dbo.Products", "Weight", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "RetailPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Products", "SalePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Products", "BrandId", c => c.Long(nullable: false));
            AddColumn("dbo.Products", "ClassificationId", c => c.Long(nullable: false));
            AddColumn("dbo.Products", "SupplierId", c => c.Long(nullable: false));
            AlterColumn("dbo.Products", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "SizeL", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "SizeH", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "SizeW", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "Cost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.Products", "BrandId");
            CreateIndex("dbo.Products", "ClassificationId");
            CreateIndex("dbo.Products", "SupplierId");
            AddForeignKey("dbo.Products", "BrandId", "dbo.Brands", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "ClassificationId", "dbo.Classifications", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers", "Id", cascadeDelete: true);
            DropColumn("dbo.Products", "Width");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Width", c => c.Decimal(precision: 18, scale: 2));
            DropForeignKey("dbo.KitTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.KitTags", "KitId", "dbo.Kits");
            DropForeignKey("dbo.KitItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Products", "ClassificationId", "dbo.Classifications");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.KitItems", "KitId", "dbo.Kits");
            DropForeignKey("dbo.KitAlternateSkus", "KitId", "dbo.Kits");
            DropForeignKey("dbo.KitAlternateCodes", "KitId", "dbo.Kits");
            DropIndex("dbo.KitTags", new[] { "TagId" });
            DropIndex("dbo.KitTags", new[] { "KitId" });
            DropIndex("dbo.Products", new[] { "SupplierId" });
            DropIndex("dbo.Products", new[] { "ClassificationId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropIndex("dbo.KitItems", new[] { "ProductId" });
            DropIndex("dbo.KitItems", new[] { "KitId" });
            DropIndex("dbo.KitAlternateSkus", new[] { "KitId" });
            DropIndex("dbo.KitAlternateCodes", new[] { "KitId" });
            AlterColumn("dbo.Products", "Cost", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Products", "SizeW", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Products", "SizeH", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Products", "SizeL", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Products", "Description", c => c.Boolean(nullable: false));
            DropColumn("dbo.Products", "SupplierId");
            DropColumn("dbo.Products", "ClassificationId");
            DropColumn("dbo.Products", "BrandId");
            DropColumn("dbo.Products", "SalePrice");
            DropColumn("dbo.Products", "RetailPrice");
            DropColumn("dbo.Products", "Weight");
            DropTable("dbo.KitTags");
            DropTable("dbo.Suppliers");
            DropTable("dbo.KitItems");
            DropTable("dbo.KitAlternateSkus");
            DropTable("dbo.Kits");
            DropTable("dbo.KitAlternateCodes");
            DropTable("dbo.Classifications");
            DropTable("dbo.Brands");
        }
    }
}
