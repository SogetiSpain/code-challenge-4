using EmployeeWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWebService
{
    public interface IDataService
    {
        Task<IEnumerable<Employee>> GetEmployeeList();
    }
}
