using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class UserInteraction
    {
        public static OrderingCriteria GetOrderingCriteria()
        {
            string input = String.Empty;
            do
            {
                Console.WriteLine("INTRO para ordenar por defecto. ");
                Console.WriteLine("En caso contrario: 1-Nombre, 2-Apellido, 3-Posición, 4-Fecha de separación");
                input = Console.ReadLine();
            } while (!IsValid(input));

            return ParseToOrderingCriteria(input);
        }

        private static OrderingCriteria ParseToOrderingCriteria(string input)
        {
            var result = OrderingCriteria.Default;
            switch (input)
            {
                case "1":
                    result = OrderingCriteria.FirstName;
                    break;
                case "2":
                    result = OrderingCriteria.LastName;
                    break;
                case "3":
                    result = OrderingCriteria.Position;
                    break;
                case "4":
                    result = OrderingCriteria.SeparationDate;
                    break;
            }
            return result;
        }

        private static bool IsValid(string input)
        {
            var trimmedInput = input.Trim();
            if (trimmedInput == String.Empty)
            {
                return true;
            }
            if (trimmedInput == "1" || trimmedInput == "2" || trimmedInput == "3" || trimmedInput == "4")
            {
                return true;
            }
            return false;
        }
    }
}
