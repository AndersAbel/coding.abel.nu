namespace TestLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Shape : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shapes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Position_XPosition = c.Int(nullable: false),
                        Position_YPosition = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Squares",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        SideLength = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shapes", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Circles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Radius = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shapes", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Circles", new[] { "Id" });
            DropIndex("dbo.Squares", new[] { "Id" });
            DropForeignKey("dbo.Circles", "Id", "dbo.Shapes");
            DropForeignKey("dbo.Squares", "Id", "dbo.Shapes");
            DropTable("dbo.Circles");
            DropTable("dbo.Squares");
            DropTable("dbo.Shapes");
        }
    }
}
