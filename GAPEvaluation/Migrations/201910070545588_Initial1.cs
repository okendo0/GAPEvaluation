namespace GAPEvaluation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClientPolicies", "Client_IdClient", "dbo.Clients");
            DropIndex("dbo.ClientPolicies", new[] { "Client_IdClient" });
            RenameColumn(table: "dbo.ClientPolicies", name: "Client_IdClient", newName: "IdClient");
            AddColumn("dbo.ClientPolicies", "CoveragePct", c => c.Single(nullable: false));
            AlterColumn("dbo.ClientPolicies", "IdClient", c => c.Int(nullable: false));
            CreateIndex("dbo.ClientPolicies", "IdClient");
            AddForeignKey("dbo.ClientPolicies", "IdClient", "dbo.Clients", "IdClient", cascadeDelete: true);
            DropColumn("dbo.ClientPolicies", "IdClient");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClientPolicies", "IdClient", c => c.Int(nullable: false));
            DropForeignKey("dbo.ClientPolicies", "IdClient", "dbo.Clients");
            DropIndex("dbo.ClientPolicies", new[] { "IdClient" });
            AlterColumn("dbo.ClientPolicies", "IdClient", c => c.Int());
            DropColumn("dbo.ClientPolicies", "CoveragePct");
            RenameColumn(table: "dbo.ClientPolicies", name: "IdClient", newName: "Client_IdClient");
            CreateIndex("dbo.ClientPolicies", "Client_IdClient");
            AddForeignKey("dbo.ClientPolicies", "Client_IdClient", "dbo.Clients", "IdClient");
        }
    }
}
