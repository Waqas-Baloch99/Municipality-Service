namespace MunicipalComplaint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updComp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.complains", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.complains", "ImagePath");
        }
    }
}
