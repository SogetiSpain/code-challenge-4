using Castle.Windsor;
using EmployeeWebService.Models;
using IServiceLayer;
using ServiceLayer.IoC;
using ServiceLayer.IoC.Configure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Program
    {
        #region Properties
        private static IWindsorContainer container;
        private static string inputValue = string.Empty;
        private static IEmployeeService employeeService;
        #endregion

        static void Main(string[] args)
        {
            
            Console.WriteLine(Resource.Apptitle);
            container = WindsorCastleContainer.Instance;
            ConfigureIoC.Configure(container);
            employeeService = container.Resolve<IEmployeeService>();
           

            while (true)
            {
                AskForValue(Resource.SelectOperation);              
                OperationDispatcher(inputValue);

                AskToContinue();
            }
        }

        #region Private Methods
        private static void OperationDispatcher(string inputValue)
        {
            switch (inputValue.ToLower())
            {
                case "n":
                    OrderByName();
                    break;
                case "p":
                    OrderByPosition();
                    break;
                case "s":
                    OrderBySeparationDate();
                    break;
            }
        }

        private static void OrderByName()
        {          
            var orderedEmployeeList = employeeService.GetEmployeeList().SortListBy<Employee>(x=> x.FirstName, GetSortDirection());
            PrintTable(orderedEmployeeList);
        }

        private static void OrderByPosition()
        {           
            var orderedEmployeeList = employeeService.GetEmployeeList().SortListBy<Employee>(x => x.Position, GetSortDirection());
            PrintTable(orderedEmployeeList);
        }

        private static void OrderBySeparationDate()
        {
            var orderedEmployeeList = employeeService.GetEmployeeList().SortListBy<Employee>(x => x.SeparationDate, GetSortDirection());
            PrintTable(orderedEmployeeList);
        }

        private static void PrintTable(IQueryable<Employee> employeeList)
        {
            Console.WriteLine(employeeList.ToStringTable(
                new[] { "First Name", "Surname", "Position", "Separation Date" },
                a => a.FirstName, a => a.LastName, a => a.Position, a => a.SeparationDate));
        }

        private static ListSortDirection GetSortDirection()
        {
            AskForValue(Resource.SortDirection);
            return inputValue.ToLower().Equals("a") ? ListSortDirection.Ascending : ListSortDirection.Descending;
        }
        private static void AskForValue(string questionMsg)
        {
            Console.WriteLine(questionMsg);
            inputValue = Console.ReadLine();
        }

        private static void AskToContinue()
        {
            Console.WriteLine(Resource.EnterKeyToContinue);
            Console.ReadKey();
            Console.Clear();
        }
        #endregion
    }
}
