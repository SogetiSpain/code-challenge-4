

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

            string readLine = String.Empty;
            ShowTable(employees);
            char op = OptionMenu();

            while (op > 0)
            {
                switch (op)
                {
                    case 'N':
                        employees = employeeService.FindByCriteria<EmployeeDTO>(employees, x => x.FirstName);
                        break;

                    case 'L':
                        employees = employeeService.FindByCriteria<EmployeeDTO>(employees, x => x.LastName);
                        break;

                    case 'P':
                        employees = employeeService.FindByCriteria<EmployeeDTO>(employees, x => x.Position);
                        break;

                    case 'D':
                        employees.OrderBy(x => x.SeparationDate);
                        break;

                    default:
                        Console.WriteLine("Por favor entra un valor existente en el menú");
                        break;
                }
                ShowTable(employees);
                op = OptionMenu();
            }
        }

        

        public static void ShowTable(IEnumerable<EmployeeDTO> employees)
        {
            Console.WriteLine("Name\t\t\t|Position\t\t|SeparationDate");
            Console.WriteLine("=====================================================================");
            foreach(var employee in employees)
            {
                Console.WriteLine(string.Format("{0}\t\t|{1}\t\t|{2}", employee.FullName, employee.Position, employee.SeparationDate.HasValue ? employee.SeparationDate.Value.ToShortDateString() : "No DateTime"));
            }
            Console.WriteLine("=====================================================================");

        }

        private static char OptionMenu()
        {
            string input = string.Empty;
            char option;
            Console.WriteLine("-------------Criterio de ordenación-------------");
            Console.WriteLine("(N) - Name");
            Console.WriteLine("(L) - LastName");
            Console.WriteLine("(P) - Position");
            Console.WriteLine("(D) - Date Separation");
            Console.WriteLine("------------------------------------------");

            input = Console.ReadLine();
            while (!char.TryParse(input, out option))
            {
                input = AskOption();
            }

            return char.ToUpper(option);
        }

        private static string AskOption()
        {
            string readLine = string.Empty;
            Console.WriteLine("Introduce una opción valida");
            readLine = Console.ReadLine();
            return readLine;
        }


    }
}
