

namespace CodeChallenge4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net.Http;
    using System.Threading.Tasks;
    using ServiceLayer;


    public class Program
    {
        static void Main(string[] args)
        {
            EmployeeService employeeService = new EmployeeService();
            IEnumerable<Employee> employees = employeeService.GetEmployees().Result;
        }

        

        public void ShowTable(IEnumerable<string> employees)
        {
            Console.WriteLine("Name    \t            |Position      \t         |SeparationDate        ");
            Console.WriteLine("--------------------------------------------------------------------");

            //iteration
            //Console.Write(string.Format(employee""));
            Console.WriteLine("--------------------|----------------------|------------------------");
            //endItertion

        }
    }
}
