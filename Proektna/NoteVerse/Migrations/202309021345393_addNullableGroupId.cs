namespace NoteVerse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNullableGroupId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notes", "GroupId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notes", "GroupId", c => c.Int(nullable: false));
        }
    }
}
