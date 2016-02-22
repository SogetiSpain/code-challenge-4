using System;

namespace BussinesLayer
{
    public class EmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public DateTime? SeparationDate { get; set; }
    }
}