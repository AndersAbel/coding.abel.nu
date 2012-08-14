namespace TestLib.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class CarsSeats : DbMigration
    {
        public override void Up()
        {
            AddColumn("Cars", "Seats", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Cars", "Seats");
        }
    }
}
