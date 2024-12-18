namespace MunicipalComplaint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.complains", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.complains", "isvalid", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.complains", "isvalid");
            DropColumn("dbo.complains", "Status");
        }
    }
}
