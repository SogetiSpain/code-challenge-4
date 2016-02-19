namespace ListOrderService
{
    using CrossCutting.Constants;
    using Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    public class Service
    {
        private const string URL = Constants.AzureEmployeesUrl;

        public async Task<List<Employee>> TakeListAndOrder()
        {
            var list = await this.GetList();
            return this.OrderList(list);
        }

        public async Task<List<Employee>> GetList()
        {
            var model = new List<Employee>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(URL);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<List<Employee>>(jsonString.Result);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }

            return model;
        }

        //public async Task<List<Employee>> OrderList(List<Employee> list)
        public List<Employee> OrderList(List<Employee> list)
        {
            return list;
        }
    }
}
