namespace TestLib.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class IX_Car_BrandId : DbMigration
    {
        public override void Up()
        {
            CreateIndex("Cars", new string[] { "BrandId", "RegistrationNumber" }, 
                true, "IX_Car_BrandId");
        }
        
        public override void Down()
        {
            DropIndex("Cars", "IX_Car_BrandId");
        }
    }
}
