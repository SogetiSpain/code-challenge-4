namespace OrderList.Model
{
    using DataLayer;
    using System;
    using System.Collections.Generic;

    public class Employee
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CompleteName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        public string Position { get; set; }

        public DateTime? SeparationDate { get; set; }

        public List<Employee> GetEmployeeList()
        {
            return EmployerDataService.GetEmployees();
        }
    }
}
