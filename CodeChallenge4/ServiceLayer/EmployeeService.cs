

namespace ServiceLayer
{
    using DataAccessLayer;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    

    public class EmployeeService
    {
        public async Task<List<EmployeeDTO>> GetEmployees()
        {
            List<EmployeeEntity> employees = await DataAccessService.GetApiData();
            return Mapper(employees);
        }


        public IEnumerable<T>OrderByCriteria<T>(IEnumerable<T> sourceList, Func<T, string> PropertyToOrder)
        {
            return sourceList.OrderBy(x => PropertyToOrder(x)).ToList();
        }


        public List<EmployeeDTO> Mapper(List<EmployeeEntity> employeesEntities)
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();

            foreach (var employeeEntity in employeesEntities)
            {
                employees.Add(new EmployeeDTO()
                {
                    FirstName = employeeEntity.FirstName,
                    LastName = employeeEntity.LastName,
                    Position = employeeEntity.Position,
                    SeparationDate = employeeEntity.SeparationDate
                });
            }
            return employees;
        }
    }    
}
