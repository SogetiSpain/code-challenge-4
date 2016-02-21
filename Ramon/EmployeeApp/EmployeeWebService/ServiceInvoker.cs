using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWebService
{
    public class ServiceInvoker : IServiceInvoker
    {
        public ServiceInvoker()
        {
        }

        public async Task<IEnumerable<T>> Get<T>()
        {
            using (var httpClient = new HttpClient())
            { 
                httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["urlWS"]);
                var endpoint = ConfigurationManager.AppSettings["endPoint"];
                
                var response = await httpClient.GetAsync(endpoint);

                response.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<IEnumerable<T>>(response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
