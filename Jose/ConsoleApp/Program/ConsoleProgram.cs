namespace CodeChallenge4.ConsoleApp.Program
{
    using CodeChallenge4.ConsoleApp.Program.Code;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;

    public class ConsoleProgram
    {
        private static ConsoleKeyInfo _ckiUser;
        private static Utils.AppCommand _appComandUser;
        private static EmployeeApp empApp;

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            empApp = new EmployeeApp();
            empApp.CallRestApi();
            do
            {
                try
                {
                    Console.TreatControlCAsInput = true;    // Prevent example from ending if CTL+C is pressed.
                    empApp.PrintMenu();
                    _ckiUser = Console.ReadKey(true);
                    _appComandUser = Utils.IsValidCommand(_ckiUser.Key.ToString());

                    switch (_appComandUser)
                    {
                        case Utils.AppCommand.InvalidInput:
                            empApp.ErrorOp();
                            break;

                        case Utils.AppCommand.SearchEmployee:
                            SearchOptions();
                            break;
                    }
                }
                catch
                {
                    empApp.ErrorOp();
                }

            } while (!Utils.IsEndCommand(_ckiUser.Key.ToString()));

        }   
   
        private static void SearchOptions()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Búsqueda de empleados \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Selecciona un criterio de ordenación: ");
            Console.WriteLine("1 - (A)pellido ");
            Console.WriteLine("2 - (N)ombre ");
            Console.WriteLine("3 - (P)osición ");
            _ckiUser = Console.ReadKey(true);
            _appComandUser = Utils.IsValidCommand(_ckiUser.Key.ToString());
            empApp.SearchEmployeeOp(_appComandUser);        
        }

    }
}
