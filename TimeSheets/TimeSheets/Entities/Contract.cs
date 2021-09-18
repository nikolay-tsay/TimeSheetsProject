using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheets.Entities
{
    public class Contract
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("FK_Employee")]
        public int EmployeeId { get; set; }

        [ForeignKey("FK_Customer")]
        public int CustomerId { get; set; }
        
        [Required]
        public string Description { get; set; }

        [Required]
        [DisplayName("Created")]
        public DateTimeOffset DateOfCreation { get; set; }

        [DisplayName("Finished")]
        public DateTimeOffset DateOfFinish { get; set; }
        
        public bool IsFinished { get; set; } = false;
    }
}