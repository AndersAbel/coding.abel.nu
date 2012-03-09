namespace TestLib.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class PhoneBookTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "PhoneBookEntries",
                c => new
                    {
                        PhoneBookEntryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.PhoneBookEntryId);
            
        }
        
        public override void Down()
        {
            DropTable("PhoneBookEntries");
        }
    }
}
