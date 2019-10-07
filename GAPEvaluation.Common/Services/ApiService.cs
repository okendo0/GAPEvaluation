namespace GAPEvaluation.Common.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using GAPEvaluation.Common.Models;
    using Newtonsoft.Json;

    public class ApiService
    {
        /// <summary>
        /// Generic Method to get a list of any kind of object
        /// </summary>
        /// <typeparam name="T">object requested</typeparam>
        /// <param name="urlBase">first part of the requested url</param>
        /// <param name="prefix">second part of thge requested url</param>
        /// <param name="controller">third part of the requested url</param>
        /// <returns></returns>
        public async Task<Response> GetList<T>(string urlBase, string prefix, string controller)
        {
            try
            {
                var client = new HttpClient(); //To make the connection with the API
                client.BaseAddress = new Uri(urlBase);
                var url = $"{prefix}{controller}";
                var response = await client.GetAsync(url);
                var answer = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = answer
                    };
                }

                var list = JsonConvert.DeserializeObject<List<T>>(answer);

                return new Response
                {
                    IsSuccess = true,
                    Result = list
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}