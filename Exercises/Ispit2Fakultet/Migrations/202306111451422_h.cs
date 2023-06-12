namespace Ispit2Fakultet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class h : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentSubjectGrades", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentSubjectGrades", "Name");
        }
    }
}
