using System;
using ServiceLayer;

namespace OrdenarListaEmpleados
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var Service = new Service();
            Console.WriteLine("Vamos con la lista de empleados");
            Console.WriteLine("¿Quiere ordenar la lista? (N)ombre, (A)pellido, (P)osicion, (F)echa de separación");
            var opcion = Console.ReadLine();
            var result = Service.ObtenerEmpleadosOrdenados(opcion);

            Console.WriteLine(result.ToStringTable(
                new[] {"Name", "Position", "Separation Date"},
                a => a.FirstName + " " + a.LastName, a => a.Position, a => a.SeparationDate));
        }
    }
}