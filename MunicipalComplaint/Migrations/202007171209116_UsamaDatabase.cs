namespace MunicipalComplaint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsamaDatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerSignups", "DOB", c => c.String());
            AlterColumn("dbo.CustomerSignups", "Gender", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerSignups", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.CustomerSignups", "DOB", c => c.String(nullable: false));
        }
    }
}
