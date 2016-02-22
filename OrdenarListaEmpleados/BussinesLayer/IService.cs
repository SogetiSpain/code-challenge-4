using System.Collections.Generic;

namespace ServiceLayer
{
    public interface IService
    {
        List<EmployeeDto> ObtenerEmpleadosOrdenados(string sortOrder);
    }
}