using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Interfaces
{
    public interface IEmployeeOrderingService
    {
        IEnumerable<Employee> OrderByDefault();
        IEnumerable<Employee> OrderBy(Func<Employee, string> orderByProperty);        
  
    }
}
