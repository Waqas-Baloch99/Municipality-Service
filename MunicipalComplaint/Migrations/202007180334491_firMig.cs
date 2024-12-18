namespace MunicipalComplaint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        DistrictId = c.Int(nullable: false, identity: true),
                        DistrictName = c.String(nullable: false),
                        ProvinceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DistrictId);
            
            CreateTable(
                "dbo.complains",
                c => new
                    {
                        ComplainId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        ComplainType = c.String(),
                        Description = c.String(),
                        DistrictId = c.Int(nullable: false),
                        TownId = c.Int(nullable: false),
                        createdat = c.String(),
                        closeDate = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ComplainId);
            
            CreateTable(
                "dbo.ContactForms",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Subject = c.String(nullable: false),
                        Message = c.String(nullable: false),
                        AddedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.CustomerSignups",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        CNIC = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Contact = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        DistrictId = c.Int(nullable: false),
                        Status = c.String(),
                        createdat = c.String(),
                        createdby = c.String(),
                        updatedat = c.String(),
                        updatedby = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        ProvinceId = c.Int(nullable: false, identity: true),
                        ProvinceName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProvinceId);
            
            CreateTable(
                "dbo.Tehsils",
                c => new
                    {
                        TehsilId = c.Int(nullable: false, identity: true),
                        TehsilName = c.String(nullable: false),
                        DistrictId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TehsilId);
            
            CreateTable(
                "dbo.UCs",
                c => new
                    {
                        UcId = c.Int(nullable: false, identity: true),
                        UCName = c.String(nullable: false),
                        TehsilId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UcId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UCs");
            DropTable("dbo.Tehsils");
            DropTable("dbo.Provinces");
            DropTable("dbo.CustomerSignups");
            DropTable("dbo.ContactForms");
            DropTable("dbo.complains");
            DropTable("dbo.Cities");
        }
    }
}
