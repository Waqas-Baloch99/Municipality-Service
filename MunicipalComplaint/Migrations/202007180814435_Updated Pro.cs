namespace MunicipalComplaint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerSignups", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerSignups", "Image");
        }
    }
}
