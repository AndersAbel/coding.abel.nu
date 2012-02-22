namespace TestLib.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Car_TopSpeed : DbMigration
    {
        public override void Up()
        {
            AddColumn("Cars", "TopSpeed", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("Cars", "TopSpeed");
        }
    }
}
