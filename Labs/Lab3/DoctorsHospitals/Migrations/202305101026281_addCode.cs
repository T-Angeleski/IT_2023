namespace DoctorsHospitals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Code", c => c.String(maxLength: 5));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "Code");
        }
    }
}
