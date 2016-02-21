using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWebService
{
    public interface IServiceInvoker
    {
        Task<IEnumerable<T>> Get<T>();
    }
}
