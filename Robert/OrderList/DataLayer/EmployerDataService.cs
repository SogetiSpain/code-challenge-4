namespace OrderList.DataLayer
{
    using Newtonsoft.Json;
    using OrderList.Model;
    using System.Collections.Generic;
    using System.Net;

    internal static class EmployerDataService
    {
        internal static List<Employee> GetEmployees()
        {
            using (var client = new WebClient())
            {
                //Se debería quitar la url de aquí y ponerla en un archivo de settings
                var json = client.DownloadString("http://codechallenge4.azurewebsites.net/api/employees");
                return JsonConvert.DeserializeObject<List<Employee>>(json);
            }
        }
    }
}
