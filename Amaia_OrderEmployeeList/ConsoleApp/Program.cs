namespace ConsoleApp
{
    using CrossCutting.Enum;
    using CrossCutting.Resources;
    using System;
    using ListOrderService;
    using System.Collections.Generic;
    using ListOrderService.Models;
    using System.Linq;
    using CrossCutting.Constants;
    class Program
    {

        private static Service service;

        static void Main(string[] args)
        {
            service = new Service();
            var exit = false;
            do
            {
                Console.WriteLine(Display.AskOrderToUser);
                Console.WriteLine(Display.Order);
                try
                {
                    string value = Console.ReadLine();
                    OrderEnum option = (OrderEnum)Enum.Parse(typeof(OrderEnum), value.ToUpper());
                    exit = MenuAction(option, exit);
                }
                catch (Exception)
                {
                    Console.WriteLine(Exceptions.LetterAskException);
                }
            } while (!exit);
        }

        public static bool MenuAction(OrderEnum option, bool exit)
        {
            var list = new List<Employee>();

            switch (option)
            {
                case OrderEnum.A:
                    list = service.TakeListAndOrder(x => x.LastName).Result;
                    PrintList(list);
                    break;
                case OrderEnum.N:
                    list = service.TakeListAndOrder(x => x.FirstName).Result;
                    PrintList(list);
                    break;
                case OrderEnum.P:
                    list = service.TakeListAndOrder(x => x.Position).Result;
                    PrintList(list);
                    break;
                case OrderEnum.F:
                    list = service.TakeListAndOrder(x => x.SeparationDate).Result;
                    PrintList(list);
                    break;
                case OrderEnum.S:
                    exit = true;
                    break;
                default:
                    break;
            }
            return exit;
        }

        public static void PrintList(IEnumerable<Employee> list)
        {
            Console.WriteLine("{0,10}|{1,15}|{2,20}|{3,17}", Display.FirstName, Display.LastName, Display.Position, Display.DateSeparation);
            Console.WriteLine(Constants.Separator);
            list.ToList().ForEach(x =>
            {
                Console.WriteLine(String.Format("{0,10}|{1,15}|{2,20}|{3,17}", x.FirstName, x.LastName, x.Position, x.SeparationDate.HasValue ? x.SeparationDate.Value.ToShortDateString() : string.Empty));
            });

            Console.WriteLine(string.Empty);
        }
    }
}
