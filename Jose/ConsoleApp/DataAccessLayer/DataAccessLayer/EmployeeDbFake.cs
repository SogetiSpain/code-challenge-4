namespace CodeChallenge4.ConsoleApp.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.Runtime.Serialization.Json;
    using System.Net.Http;
    using System.Net.Http.Headers;

    public class EmployeeDbFake
    {
        public const string UrlApiRESTData = "http://codechallenge4.azurewebsites.net/";
        private static List<EmployeeEntity> _employeeTable = new List<EmployeeEntity>();

        public async Task<List<EmployeeEntity>> GeResttData() 
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(UrlApiRESTData);
            using (var client = new HttpClient())
            {
                // New code:
                client.BaseAddress = new Uri(UrlApiRESTData);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.GetAsync("api/employees");
                if (response.IsSuccessStatusCode)
                {
                    _employeeTable = await response.Content.ReadAsAsync<List<EmployeeEntity>>();
                    return _employeeTable;
                }
            }
            return null;
        
        }

        public List<EmployeeEntity> GetAllItems() 
        {
            return _employeeTable;
        }

        public void SetDbData(List<EmployeeEntity> dbEmployee) 
        {
            _employeeTable = dbEmployee;
        }

    }
}
