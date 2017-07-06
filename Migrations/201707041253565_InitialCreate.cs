namespace blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restuarants",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.RestaurantReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Body = c.String(),
                        RestuarantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restuarants", t => t.RestuarantId, cascadeDelete: true)
                .Index(t => t.RestuarantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RestaurantReviews", "RestuarantId", "dbo.Restuarants");
            DropIndex("dbo.RestaurantReviews", new[] { "RestuarantId" });
            DropTable("dbo.RestaurantReviews");
            DropTable("dbo.Restuarants");
        }
    }
}
