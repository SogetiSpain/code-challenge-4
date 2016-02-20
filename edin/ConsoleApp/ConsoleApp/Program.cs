using DataLayer;
using DataLayer.Implementations;
using EmployeeService.Implementations;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dependencias
            var dataProvider = DataProviderFactory.Create(false);
            var service = new EmployeeOrderingService(dataProvider);

            // Interacción 
            var orderingCriteria = UserInteraction.GetOrderingCriteria();
            
            // Ejecución
            DoOrdering(orderingCriteria, service);

            Console.ReadLine();
        }

        private static Dictionary<OrderingCriteria, Func<IEnumerable<Employee>>> CreateOrdersMapping(EmployeeOrderingService service)
        {
            var result = new Dictionary<OrderingCriteria, Func<IEnumerable<Employee>>>();

            result.Add(OrderingCriteria.Default, service.OrderByDefault);
            result.Add(OrderingCriteria.FirstName, () => service.OrderBy(x=>x.FirstName));
            result.Add(OrderingCriteria.LastName, () => service.OrderBy(x=>x.LastName));
            result.Add(OrderingCriteria.Position, () => service.OrderBy(x=>x.Position));
            result.Add(OrderingCriteria.SeparationDate, () => service.OrderBy(x=>x.SeparationDateToString));

            return result;
        }



        private static void DoOrdering(OrderingCriteria criteria, EmployeeOrderingService service)
        {
            var mapping = CreateOrdersMapping(service);
            var orderingMethod = mapping[criteria];
            IEnumerable<Employee> employees = orderingMethod();
            PrintResult(employees);
        }

 
        private static void PrintResult(IEnumerable<Employee> employees)
        {
            var formatDimensions = new FormatDimensions(employees);

            PrintHeader(formatDimensions);
            foreach (var employee in employees)
            {
                PrintEmployee(employee, formatDimensions);
            }

        }

        private static void PrintHeader(FormatDimensions formatDimensions)
        {
            Console.WriteLine(formatDimensions.ToFormatString(), "Name", "Position", "Separation Date");
            Console.WriteLine(String.Empty.PadRight(formatDimensions.TotalWidth(), '-'));
        }

        private static void PrintEmployee(Employee employee, FormatDimensions formatDimensions)
        {
            Console.WriteLine(formatDimensions.ToFormatString(), 
                employee.FullName, 
                employee.Position, 
                employee.SeparationDateToString);
        }
    }
}
