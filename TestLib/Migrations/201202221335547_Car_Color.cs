namespace TestLib.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Car_Color : DbMigration
    {
        public override void Up()
        {
            // My Comment
            AddColumn("Cars", "Color", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("Cars", "Color");
        }
    }
}
