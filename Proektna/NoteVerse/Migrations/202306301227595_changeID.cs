namespace NoteVerse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeID : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notes", "userId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notes", "userId", c => c.Int(nullable: false));
        }
    }
}
