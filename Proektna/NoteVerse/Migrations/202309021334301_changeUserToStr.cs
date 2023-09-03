namespace NoteVerse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeUserToStr : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GroupedNotes", "UserId", c => c.String());
            AlterColumn("dbo.Notes", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notes", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.GroupedNotes", "UserId", c => c.Int(nullable: false));
        }
    }
}
