namespace TestLib.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PeopleTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        BirthYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId)
                .Index(p => new { p.BirthYear, p.PersonId });

        }

        public override void Down()
        {
            DropTable("People");
        }
    }
}
