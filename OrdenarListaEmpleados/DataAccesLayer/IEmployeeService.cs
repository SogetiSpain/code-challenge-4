using System.Collections.Generic;

namespace DataAccesLayer
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
    }
}