namespace NoteVerse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class todo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ToDoTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        content = c.String(),
                        isComplete = c.Boolean(nullable: false),
                        Note_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Notes", t => t.Note_Id)
                .Index(t => t.Note_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDoTasks", "Note_Id", "dbo.Notes");
            DropIndex("dbo.ToDoTasks", new[] { "Note_Id" });
            DropTable("dbo.ToDoTasks");
        }
    }
}
