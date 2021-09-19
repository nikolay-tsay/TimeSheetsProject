using System.Collections.Generic;
using TimeSheets.Entities;

namespace TimeSheets.DTO
{
    public class EmployeeDto
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public decimal Rate { get; set; }

        public List<Contract> Contracts { get; set; }
    }
}