namespace GAPEvaluation.Domain.Models
{
    using System.Data.Entity;

    public class DataContext: DbContext
    {
        public DataContext(): base("GAPConnection")
        {
            
        }

        public DbSet<Policy> Policies { get; set; }
        public DbSet<Coverage> Coverages { get; set; }
        public DbSet<RiskType> RiskTypes { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientPolicy> ClientPolicies { get; set; }
    }
}
