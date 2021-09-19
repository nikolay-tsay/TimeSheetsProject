using System;

namespace TimeSheets.DTO
{
    public class ContractDto
    {

        public string ContractName { get; set; }
        
        public int CustomerId { get; set; }
        
        public int EmployeeId { get; set; }

        public string Description { get; set; }
        
        public decimal Price { get; set; }
        
        public DateTimeOffset DateOfCreation { get; set; }

        public DateTimeOffset DateOfFinish { get; set; }
        
        public bool IsFinished { get; set; } 
    }
}