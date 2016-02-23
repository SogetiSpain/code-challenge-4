
namespace CodeChallenge4.ConsoleApp.Program.Code
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CodeChallenge4.ServiceLayer;
    using CodeChallenge4.ServiceLayer.Interface;
    using CodeChallenge4.ServiceLayer.Implementation;
    using CodeChallenge4.ServiceLayer.DTO;
    using System.Globalization;

    public class EmployeeApp
    {
        private static readonly IWindsorContainer _container = new WindsorContainer();
        public IEmployeeAppService _employeeAppService;

        private const string _dataTableCol1Title1 = "Name";
        private const string _dataTableCol1Title2 = "Position";
        private const string _dataTableCol1Title3 = "Name";

        internal static IWindsorContainer Container
        {
            get { return EmployeeApp._container; }
        }

        public EmployeeApp() 
        {
            try
            {
                EmployeeApp._container.Register(Component.For<IEmployeeAppService>().ImplementedBy<EmployeeAppService>());
            }
            catch 
            { 
            
            }
            _employeeAppService = EmployeeApp._container.Resolve<IEmployeeAppService>();        
        }

        public void Dispose() 
        {

        }
        //public void Init() 
        //{
        //    EmployeeApp._container.Register(Component.For<IEmployeeAppService>().ImplementedBy<EmployeeAppService>());
        //    _employeeAppService = EmployeeApp._container.Resolve<IEmployeeAppService>();
        //}

        public void PrintMenu() 
        {
            Console.WriteLine("--------------------------------- ");
            Console.WriteLine("Presiona Escape (Esc) para cerrar la aplicación");
            Console.WriteLine("Selecciona una operación: ");
            Console.WriteLine("1 - (B)úsqueda ");
            Console.WriteLine("--------------------------------- ");
        }

        public void ErrorOp()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Operación no válida. Por favor, introduzca una instrucción permitida. \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------- \n");

        }

        public List<EmployeeDto> SearchEmployeeOp(Utils.AppCommand appComandUser)
        {
            List<EmployeeDto> allEmployeesList = null;

            switch (appComandUser)
            {
                case Utils.AppCommand.InvalidInput:
                    ErrorOp();
                    break;

                case Utils.AppCommand.OrderByName:
                    allEmployeesList = _employeeAppService.GetAllEmployeesBy("FirstName");
                    PrintDataTable(allEmployeesList);
                    break;

                case Utils.AppCommand.OrderByPosition:
                    allEmployeesList = _employeeAppService.GetAllEmployeesBy("Position");
                    PrintDataTable(allEmployeesList);
                    break;

                case Utils.AppCommand.OrderByLastName:
                    allEmployeesList = _employeeAppService.GetAllEmployeesBy("LastName");
                    PrintDataTable(allEmployeesList);
                    break;
            }

            return allEmployeesList;
        }

        public void PrintDataTable(List<EmployeeDto> allEmployeesList) 
        {
            Utils.ConsoleTable consoleTableeEmployees = new Utils.ConsoleTable(_dataTableCol1Title1, _dataTableCol1Title2, _dataTableCol1Title3);
            foreach (EmployeeDto employeeItem in allEmployeesList) 
            {
                consoleTableeEmployees.AddRow( employeeItem.FirstName + " " + employeeItem.LastName, employeeItem.Position.ToString(), employeeItem.SeparationDate.ToString());            
            }
            consoleTableeEmployees.Write();
            Console.WriteLine();
        }

        public void SetData(List<EmployeeDto> allEmployeesList) 
        {
            _employeeAppService.SetData(allEmployeesList);
        }

        public async Task<List<EmployeeDto>> CallRestApi() 
        {
            return (await _employeeAppService.GetRestData());
        }

    }
}
