namespace NoteVerse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class redomodels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ToDoTasks", "Note_Id", "dbo.Notes");
            DropIndex("dbo.ToDoTasks", new[] { "Note_Id" });
            CreateTable(
                "dbo.TodoNotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        userId = c.Int(nullable: false),
                        title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.ToDoTasks");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.TodoNotes");
            CreateIndex("dbo.ToDoTasks", "Note_Id");
            AddForeignKey("dbo.ToDoTasks", "Note_Id", "dbo.Notes", "Id");
        }
    }
}
