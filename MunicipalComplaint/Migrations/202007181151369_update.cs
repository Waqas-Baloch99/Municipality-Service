namespace MunicipalComplaint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerSignups", "Image", c => c.String());
            AddColumn("dbo.CustomerSignups", "DOB", c => c.String());
            AddColumn("dbo.CustomerSignups", "Gender", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerSignups", "Gender");
            DropColumn("dbo.CustomerSignups", "DOB");
            DropColumn("dbo.CustomerSignups", "Image");
        }
    }
}
