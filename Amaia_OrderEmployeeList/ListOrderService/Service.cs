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
    using System.Linq;

    public class Service
    {
        private const string URL = Constants.AzureEmployeesUrl;

        public async Task<List<Employee>> TakeListAndOrder<T>(Func<Employee, T> orderByProperty)
        {
            var list = await this.GetList();
            return this.OrderList(list, orderByProperty);
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

        public List<Employee> OrderList<T>(List<Employee> list, Func<Employee, T> orderByProperty)
        {
            list.OrderBy(orderByProperty);
            return list;
        }
    }
}
