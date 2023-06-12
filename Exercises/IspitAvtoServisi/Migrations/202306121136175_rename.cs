namespace IspitAvtoServisi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rename : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AutoServices", newName: "AutoServisis");
            RenameTable(name: "dbo.CarAutoServices", newName: "CarAutoServisis");
            RenameColumn(table: "dbo.CarAutoServisis", name: "AutoService_Id", newName: "AutoServisi_Id");
            RenameIndex(table: "dbo.CarAutoServisis", name: "IX_AutoService_Id", newName: "IX_AutoServisi_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CarAutoServisis", name: "IX_AutoServisi_Id", newName: "IX_AutoService_Id");
            RenameColumn(table: "dbo.CarAutoServisis", name: "AutoServisi_Id", newName: "AutoService_Id");
            RenameTable(name: "dbo.CarAutoServisis", newName: "CarAutoServices");
            RenameTable(name: "dbo.AutoServisis", newName: "AutoServices");
        }
    }
}
