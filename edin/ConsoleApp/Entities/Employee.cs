using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public DateTime? SeparationDate { get; set; }

        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }

        public string SeparationDateToString
        {
            get
            {
                return this.SeparationDate.HasValue ? 
                    this.SeparationDate.Value.ToString("yyyy-MM-dd") : String.Empty;
            }
        }
    }
}
