namespace GAPEvaluation.Models
{
    using Domain.Models;

    public class LocalDataContext: DataContext
    {
        public System.Data.Entity.DbSet<GAPEvaluation.Domain.Models.Policy> Policies { get; set; }

        public System.Data.Entity.DbSet<GAPEvaluation.Domain.Models.Client> Clients { get; set; }

        public System.Data.Entity.DbSet<GAPEvaluation.Domain.Models.Coverage> Coverages { get; set; }

        public System.Data.Entity.DbSet<GAPEvaluation.Domain.Models.RiskType> RiskTypes { get; set; }
    }
}