namespace MunicipalComplaint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rasd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.complains", "AdminMessage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.complains", "AdminMessage");
        }
    }
}
