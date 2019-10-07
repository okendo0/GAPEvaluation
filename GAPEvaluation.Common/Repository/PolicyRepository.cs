namespace GAPEvaluation.Common.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Services;
    using Domain.Models;

    public class PolicyRepository: BaseRepository
    {
        ApiService apiService = new ApiService();

        public async Task<List<Policy>> GetPolicies()
        {
            var response = await this.apiService.GetList<Policy>("http://localhost:64959", "/api", "/Policies");
            if (response.IsSuccess)
            {
                return (List<Policy>)response.Result;
            }
            else
            {
                return new List<Policy>();
            }
        }
    }
}
