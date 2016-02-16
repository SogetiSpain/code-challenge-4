namespace ConsoleApp
{
    using CrossCutting.Enum;
    using CrossCutting.Resources;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
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
                case OrderEnum.A:
                    break;
                case OrderEnum.N:
                    break;
                case OrderEnum.P:
                    break;
                case OrderEnum.F:
                    break;
                case OrderEnum.S:
                    exit = true;
                    break;
                default:
                    break;
            }

            return exit;
        }
    }
}
