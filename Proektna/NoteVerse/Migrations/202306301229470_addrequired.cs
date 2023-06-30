namespace NoteVerse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notes", "title", c => c.String(nullable: false));
            AlterColumn("dbo.Notes", "content", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notes", "content", c => c.String());
            AlterColumn("dbo.Notes", "title", c => c.String());
        }
    }
}
