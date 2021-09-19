using System;
using System.Collections.Generic;
using TimeSheets.Entities;

namespace TimeSheets.DTO
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        
        public TimeSpan TotalHours { get; set; }

        public decimal TotalPrice { get; set; }
        
        public string Comment { get; set; }
        
        public bool IsClosed { get; set; } 
        
        public List<Contract> Contracts { get; set; }
    }
}