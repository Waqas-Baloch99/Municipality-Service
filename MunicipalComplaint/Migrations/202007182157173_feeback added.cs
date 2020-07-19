namespace MunicipalComplaint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class feebackadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        feedbackID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        complainID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.feedbackID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Feedbacks");
        }
    }
}
