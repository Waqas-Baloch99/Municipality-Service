namespace MunicipalComplaint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerSignups", "DOB", c => c.String(nullable: false));
            AddColumn("dbo.CustomerSignups", "Gender", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerSignups", "Gender");
            DropColumn("dbo.CustomerSignups", "DOB");
        }
    }
}
