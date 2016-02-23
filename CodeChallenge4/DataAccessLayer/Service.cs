

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Constants;

    public static class DataAccessService
    {

        public static async Task<List<EmployeeEntity>> GetApiData()
        {
            List<EmployeeEntity> employees = new List<EmployeeEntity>();
            var client = new HttpClient();

            client.BaseAddress = new Uri(Constants.Constants.DataUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.Constants.ResponseHeaderType));

            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            if (response.IsSuccessStatusCode)
            {
                employees = await response.Content.ReadAsAsync<List<EmployeeEntity>>();
            }

            return employees;
        }
        
    }
}
