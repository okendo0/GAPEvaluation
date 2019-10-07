namespace GAPEvaluation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientPolicies",
                c => new
                    {
                        IdClientPolicy = c.Int(nullable: false, identity: true),
                        IdClient = c.Int(nullable: false),
                        IdPolicy = c.Int(nullable: false),
                        IdRiskType = c.Int(nullable: false),
                        Client_IdClient = c.Int(),
                    })
                .PrimaryKey(t => t.IdClientPolicy)
                .ForeignKey("dbo.Clients", t => t.Client_IdClient)
                .ForeignKey("dbo.Policies", t => t.IdPolicy, cascadeDelete: true)
                .ForeignKey("dbo.RiskTypes", t => t.IdRiskType, cascadeDelete: true)
                .Index(t => t.IdPolicy)
                .Index(t => t.IdRiskType)
                .Index(t => t.Client_IdClient);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        IdClient = c.Int(nullable: false, identity: true),
                        IdNumber = c.String(maxLength: 20),
                        FirstName = c.String(maxLength: 30),
                        LastName = c.String(maxLength: 30),
                        BirthDate = c.String(),
                    })
                .PrimaryKey(t => t.IdClient);
            
            CreateTable(
                "dbo.Policies",
                c => new
                    {
                        IdPolicy = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Description = c.String(),
                        IdCoverage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPolicy)
                .ForeignKey("dbo.Coverages", t => t.IdCoverage, cascadeDelete: true)
                .Index(t => t.IdCoverage);
            
            CreateTable(
                "dbo.Coverages",
                c => new
                    {
                        IdCoverage = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        CoveragePct = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.IdCoverage);
            
            CreateTable(
                "dbo.RiskTypes",
                c => new
                    {
                        IdRiskType = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.IdRiskType);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientPolicies", "IdRiskType", "dbo.RiskTypes");
            DropForeignKey("dbo.Policies", "IdCoverage", "dbo.Coverages");
            DropForeignKey("dbo.ClientPolicies", "IdPolicy", "dbo.Policies");
            DropForeignKey("dbo.ClientPolicies", "Client_IdClient", "dbo.Clients");
            DropIndex("dbo.Policies", new[] { "IdCoverage" });
            DropIndex("dbo.ClientPolicies", new[] { "Client_IdClient" });
            DropIndex("dbo.ClientPolicies", new[] { "IdRiskType" });
            DropIndex("dbo.ClientPolicies", new[] { "IdPolicy" });
            DropTable("dbo.RiskTypes");
            DropTable("dbo.Coverages");
            DropTable("dbo.Policies");
            DropTable("dbo.Clients");
            DropTable("dbo.ClientPolicies");
        }
    }
}
