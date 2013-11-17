namespace TestLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarBodyStyle : DbMigration
    {
public override void Up()
{
    CreateTable("dbo.CarBodyStyles",
        c => new
        {
            Id = c.Int(nullable: false),
            Description = c.String(maxLength: 50)
        }).PrimaryKey(t => t.Id);

    Sql("INSERT CarBodyStyles VALUES (0, 'Not Defined') ");

    AddColumn("dbo.Cars", "BodyStyle", c => c.Int(nullable: false));
            
    AddForeignKey("dbo.Cars", "BodyStyle", "dbo.CarBodyStyles");
}
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "BodyStyle", "dbo.CarBodyStyles");
            DropColumn("dbo.Cars", "BodyStyle");
            DropTable("dbo.CarBodyStyles");
        }
    }
}
