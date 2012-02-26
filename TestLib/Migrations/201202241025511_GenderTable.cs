namespace TestLib.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class GenderTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Genders",
                c => new
                    {
                        GenderId = c.Byte(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.GenderId);
            
        }
        
        public override void Down()
        {
            DropTable("Genders");
        }
    }
}
