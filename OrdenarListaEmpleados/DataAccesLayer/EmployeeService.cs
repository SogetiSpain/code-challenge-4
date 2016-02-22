using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DataAccesLayer
{
    public class EmployeeService : IEmployeeService
    {
        public List<Employee> GetEmployees()
        {
            var employeeList = new List<Employee>();
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://codechallenge4.azurewebsites.net/api/employees")
            };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(client.BaseAddress).Result;
            if (!response.IsSuccessStatusCode)
            {
                return employeeList;
            }
            var dataObjects = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
            employeeList.AddRange(dataObjects);
            return employeeList;
        }
    }
}