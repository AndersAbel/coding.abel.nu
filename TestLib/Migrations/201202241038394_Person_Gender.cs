namespace TestLib.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Person_Gender : DbMigration
    {
        public override void Up()
        {
            AddColumn("People", "GenderId", c => c.Byte(nullable: false));
            AddForeignKey("People", "GenderId", "Genders", "GenderId", cascadeDelete: true);
            CreateIndex("People", "GenderId");
        }
        
        public override void Down()
        {
            DropIndex("People", new[] { "GenderId" });
            DropForeignKey("People", "GenderId", "Genders");
            DropColumn("People", "GenderId");
        }
    }
}
