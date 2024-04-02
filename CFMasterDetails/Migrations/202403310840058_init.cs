namespace CFMasterDetails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applicants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        TotalExp = c.Int(nullable: false),
                        PicPath = c.String(),
                        IsAvilable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicantExpriences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Designation = c.String(),
                        YearOfExprience = c.Int(nullable: false),
                        ApplicantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applicants", t => t.ApplicantId, cascadeDelete: true)
                .Index(t => t.ApplicantId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicantExpriences", "ApplicantId", "dbo.Applicants");
            DropIndex("dbo.ApplicantExpriences", new[] { "ApplicantId" });
            DropTable("dbo.Employees");
            DropTable("dbo.ApplicantExpriences");
            DropTable("dbo.Applicants");
        }
    }
}
