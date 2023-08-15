namespace NoteVerse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testnewstring : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TodoNotes", "allTasksCS", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TodoNotes", "allTasksCS");
        }
    }
}
