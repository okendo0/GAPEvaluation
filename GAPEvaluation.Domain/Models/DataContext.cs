namespace GAPEvaluation.Domain.Models
{
    using System.Data.Entity;

    public class DataContext: DbContext
    {
        public DataContext(): base("GAPConnection")
        {

        }

        public System.Data.Entity.DbSet<GAPEvaluation.Common.Models.Policy> Policies { get; set; }
    }
}
