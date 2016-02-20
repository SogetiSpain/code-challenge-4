using DataLayer.Interfaces;
using EmployeeService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Implementations
{
    public class EmployeeOrderingService : IEmployeeOrderingService
    {
        private readonly IEmployeeData _dataProvider;

        public EmployeeOrderingService(IEmployeeData dataProvider)
        {
            this._dataProvider = dataProvider;
        }

        public IEnumerable<Entities.Employee> OrderByDefault()
        {
            return this.OrderBy(x => x.FullName);
        }

        public IEnumerable<Entities.Employee> OrderBy(Func<Entities.Employee, string> orderByProperty)
        {
            var employees = this._dataProvider.GetEmployees();
            return employees.OrderBy(orderByProperty);
        }
    }
}
