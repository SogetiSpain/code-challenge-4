using EmployeeWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTest
{
    public class EmployeeListComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            if (object.ReferenceEquals(x, y)) return true;

            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null)) return false;

            return x.FirstName == y.FirstName && x.LastName == y.LastName && x.Position == y.Position && x.SeparationDate == y.SeparationDate;
        }

        public int GetHashCode(Employee obj)
        {
            if (object.ReferenceEquals(obj, null)) return 0;

            int hashCodeName = obj.FirstName == null ? 0 : obj.FirstName.GetHashCode();
            int hashCodeLastName = obj.LastName == null ? 0 : obj.LastName.GetHashCode();
            int hashCodePosition = obj.Position.GetHashCode();

            return hashCodeName ^ hashCodeLastName ^ hashCodePosition;
        }
    }
}
