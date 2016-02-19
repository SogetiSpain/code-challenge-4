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
            switch (option)
            {
                case OrderEnum.S:
                    exit = true;
                    break;
                default:
                    var list = service.TakeListAndOrder().Result;
                    PrintList(list);
                    break;
            }

            return exit;
        }

        public static void PrintList(IEnumerable<Employee> list)
        {
            Console.WriteLine("{0,30}|{1,20}|{2,17}", Display.Name, Display.Position, Display.DateSeparation);
            Console.WriteLine(Constants.Separator);
            list.ToList().ForEach(x =>
            {
                var name = string.Format("{0} {1}", x.FirstName, x.LastName);
                Console.WriteLine(String.Format("{0,30}|{1,20}|{2,17}", name, x.Position, x.SeparationDate.HasValue ? x.SeparationDate.Value.ToShortDateString() : string.Empty));
            });

            Console.WriteLine(string.Empty);
        }
    }
}
