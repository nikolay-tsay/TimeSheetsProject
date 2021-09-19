using System.Collections.Generic;
using TimeSheets.Entities;

namespace TimeSheets.DTO
{
    public class CustomerDto
    {
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Contract> Contracts { get; set; }

        public List<Invoice> Invoices { get; set; }
    }
}