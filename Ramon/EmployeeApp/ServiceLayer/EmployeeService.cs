using IServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeWebService.Models;
using System.Linq.Expressions;
using EmployeeWebService;

namespace ServiceLayer
{
    public class EmployeeService : IEmployeeService
    {
        private IDataService dataService;

        public EmployeeService(IDataService dataService)
        {
            this.dataService = dataService;
        }
        public IQueryable<Employee> GetEmployeeList()
        {
            return dataService.GetEmployeeList().Result.AsQueryable();               
        }
    }
}
