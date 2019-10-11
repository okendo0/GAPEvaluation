namespace GAPEvaluation.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using GAPEvaluation.Domain.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<GAPEvaluation.Models.LocalDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(GAPEvaluation.Models.LocalDataContext context)
        {
            //Add Policies
            context.Policies.AddOrUpdate(x => x.IdPolicy, new Policy() { IdPolicy = 1, Name = "Vehiculos", Description = "Pòliza para Vehìculos", IdCoverage = 2 });
            context.Policies.AddOrUpdate(x => x.IdPolicy, new Policy() { IdPolicy = 2, Name = "Empresas", Description = "Pòliza para Empresas", IdCoverage = 1 });
            context.Policies.AddOrUpdate(x => x.IdPolicy, new Policy() { IdPolicy = 2, Name = "Viajes", Description = "Pòliza para Empresas", IdCoverage = 3 });

            //Adding Clients
            context.Clients.AddOrUpdate(x => x.IdClient,
                new Client() { IdClient = 1, FirstName = "Oswaldo", LastName = "Oquendo", IdNumber = "79290616", BirthDate = DateTime.Now.AddMonths(-300).ToShortDateString() });
            context.Clients.AddOrUpdate(x => x.IdClient,
                new Client() { IdClient = 2, FirstName = "Olga", LastName = "Rojas", IdNumber = "52095055", BirthDate = DateTime.Now.AddMonths(-280).ToShortDateString() });
            
            ///Adding Coverages
            context.Coverages.AddOrUpdate(x => x.IdCoverage, new Coverage() { IdCoverage = 1, Name = "Terremoto", CoveragePct = 50 });
            context.Coverages.AddOrUpdate(x => x.IdCoverage, new Coverage() { IdCoverage = 2, Name = "Incendio", CoveragePct = 80 });
            context.Coverages.AddOrUpdate(x => x.IdCoverage, new Coverage() { IdCoverage = 3, Name = "Robo", CoveragePct = 15 });
            context.Coverages.AddOrUpdate(x => x.IdCoverage, new Coverage() { IdCoverage = 4, Name = "Perdida", CoveragePct = 10 });

            ///Adding Risks
            context.RiskTypes.AddOrUpdate(x => x.IdRiskType, new RiskType() { IdRiskType = 1, Name = "Bajo" });
            context.RiskTypes.AddOrUpdate(x => x.IdRiskType, new RiskType() { IdRiskType = 2, Name = "Medio" });
            context.RiskTypes.AddOrUpdate(x => x.IdRiskType, new RiskType() { IdRiskType = 3, Name = "Medio-Alto" });
            context.RiskTypes.AddOrUpdate(x => x.IdRiskType, new RiskType() { IdRiskType = 4, Name = "Alto" });
        }
    }
}
