

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
            IEnumerable<EmployeeDTO> employees = employeeService.GetEmployees().Result;

            ShowTable(employees);
            Console.ReadLine();
        }





        public static void ShowTable(IEnumerable<EmployeeDTO> employees)
        {
            Console.WriteLine("Name\t\t\t|Position\t\t|SeparationDate");
            Console.WriteLine("--------------------------------------------------------------------");

            foreach(var employee in employees)
            {
                Console.WriteLine(string.Format("{0}\t\t|{1}\t\t|{2}", employee.FullName, employee.Position, employee.SeparationDate.HasValue ? employee.SeparationDate.Value.ToShortDateString() : "No DateTime"));
            }
            Console.WriteLine("--------------------------------------------------------------------");
            

        }


    }
}
