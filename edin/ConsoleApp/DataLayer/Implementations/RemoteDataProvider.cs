using DataLayer.Interfaces;
using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implementations
{
    public class RemoteDataProvider: IEmployeeData
    {
        private string dataUri;

        public RemoteDataProvider(string dataUri)
        {
            this.dataUri = dataUri;
        }

        public IEnumerable<Entities.Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                string json = MakeJsonHttpRequest(dataUri);
                employees = JsonConvert.DeserializeObject<List<Employee>>(json);
            }
            catch
            {

            }
            return employees;
        }

        private string MakeJsonHttpRequest(string dataUri)
        {
            var result = String.Empty;

            WebRequest request = WebRequest.CreateHttp(dataUri);
            request.ContentType = "application/json; charset=utf-8";
            var response = request.GetResponse();

            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                result = sr.ReadToEnd();
            }
            return result;
        }
    }
}
