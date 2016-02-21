using DataLayer.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implementations
{
    public class LocalDataProvider: IEmployeeData
    {
        public IEnumerable<Entities.Employee> GetEmployees()
        {
            var list = new List<Employee>();
            list.Add(new Employee() { FirstName = "John", LastName = "Johnson", Position = "Manager", SeparationDate = new DateTime(2016, 12, 31) });
            list.Add(new Employee() { FirstName = "Tou", LastName = "Xiong", Position = "Software Engineer", SeparationDate = new DateTime(2016, 10, 05) });
            list.Add(new Employee() { FirstName = "Michaela", LastName = "Michaelson", Position = "District Manager", SeparationDate = new DateTime(2015, 12, 19) });
            list.Add(new Employee() { FirstName = "Jake", LastName = "Jacobson", Position = "Programmer", SeparationDate = null });
            list.Add(new Employee() { FirstName = "Jacquelyn", LastName = "Jackson", Position = "DBA", SeparationDate = null });
            list.Add(new Employee() { FirstName = "Sally", LastName = "Weber", Position = "Web Developer", SeparationDate = new DateTime(2015, 12, 18) });
            return list;
        }
    }
}
