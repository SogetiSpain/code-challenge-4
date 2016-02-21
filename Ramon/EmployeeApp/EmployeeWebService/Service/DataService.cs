using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeWebService.Models;

namespace EmployeeWebService.Service
{
    public class DataService : IDataService
    {
        private IServiceInvoker invoker;

        public DataService(IServiceInvoker ivk)
        {
            this.invoker = ivk;
        }
        public async Task<IEnumerable<Employee>> GetEmployeeList()
        {
            return await invoker.Get<Employee>();
        }
    }
}
