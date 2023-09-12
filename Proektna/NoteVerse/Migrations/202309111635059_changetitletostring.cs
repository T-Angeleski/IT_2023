namespace NoteVerse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetitletostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GroupedNotes", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GroupedNotes", "Title", c => c.Int(nullable: false));
        }
    }
}
