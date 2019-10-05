namespace GAPEvaluation.Models
{
    using Domain.Models;

    public class LocalDataContext: DataContext
    {
        public System.Data.Entity.DbSet<GAPEvaluation.Common.Models.Policy> Policies { get; set; }
    }
}