using System.Collections.Generic;

namespace BussinesLayer
{
    public interface IBussinesService
    {
        List<EmployeeDto> ObtenerEmpleadosOrdenados(string sortOrder);
    }
}