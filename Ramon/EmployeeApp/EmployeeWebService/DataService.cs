using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeWebService.Models;

namespace EmployeeWebService
{
    public class DataService : IDataService
    {
        private IServiceInvoker ivkService;
        public DataService(IServiceInvoker ivkService)
        {
            this.ivkService = ivkService;
        }

        public async Task<IEnumerable<Employee>> GetEmployeeList()
        {
            return await ivkService.Get<Employee>();
        }
    }
}
