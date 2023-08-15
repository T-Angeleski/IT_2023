namespace NoteVerse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intotstr : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TodoNotes", "userId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TodoNotes", "userId", c => c.Int(nullable: false));
        }
    }
}
