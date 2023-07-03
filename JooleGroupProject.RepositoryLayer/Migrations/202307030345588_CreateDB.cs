namespace JooleGroupProject.RepositoryLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attribute",
                c => new
                    {
                        AttributeID = c.Int(nullable: false, identity: true),
                        AttributeName = c.String(),
                        IsTechSpec = c.Boolean(nullable: false),
                        IsType = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AttributeID);
            
            CreateTable(
                "dbo.ProductAttribute",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        AttributeID = c.Int(nullable: false),
                        AttributeValue = c.String(),
                    })
                .PrimaryKey(t => new { t.ProductID, t.AttributeID })
                .ForeignKey("dbo.Attribute", t => t.AttributeID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.AttributeID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        SubCategoryID = c.Int(nullable: false),
                        ProductName = c.String(),
                        Model = c.String(),
                        Manufacturer = c.String(),
                        Series = c.String(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.SubCategory", t => t.SubCategoryID, cascadeDelete: true)
                .Index(t => t.SubCategoryID);
            
            CreateTable(
                "dbo.SubCategory",
                c => new
                    {
                        SubCategoryID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        SubCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.SubCategoryID)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.TechSpecFilter",
                c => new
                    {
                        SubCategoryID = c.Int(nullable: false),
                        AttributeID = c.Int(nullable: false),
                        MaxValue = c.Int(nullable: false),
                        MinValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubCategoryID, t.AttributeID })
                .ForeignKey("dbo.Attribute", t => t.AttributeID, cascadeDelete: true)
                .ForeignKey("dbo.SubCategory", t => t.SubCategoryID, cascadeDelete: true)
                .Index(t => t.SubCategoryID)
                .Index(t => t.AttributeID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TechSpecFilter", "SubCategoryID", "dbo.SubCategory");
            DropForeignKey("dbo.TechSpecFilter", "AttributeID", "dbo.Attribute");
            DropForeignKey("dbo.Product", "SubCategoryID", "dbo.SubCategory");
            DropForeignKey("dbo.SubCategory", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.ProductAttribute", "ProductID", "dbo.Product");
            DropForeignKey("dbo.ProductAttribute", "AttributeID", "dbo.Attribute");
            DropIndex("dbo.TechSpecFilter", new[] { "AttributeID" });
            DropIndex("dbo.TechSpecFilter", new[] { "SubCategoryID" });
            DropIndex("dbo.SubCategory", new[] { "CategoryID" });
            DropIndex("dbo.Product", new[] { "SubCategoryID" });
            DropIndex("dbo.ProductAttribute", new[] { "AttributeID" });
            DropIndex("dbo.ProductAttribute", new[] { "ProductID" });
            DropTable("dbo.User");
            DropTable("dbo.TechSpecFilter");
            DropTable("dbo.Category");
            DropTable("dbo.SubCategory");
            DropTable("dbo.Product");
            DropTable("dbo.ProductAttribute");
            DropTable("dbo.Attribute");
        }
    }
}
