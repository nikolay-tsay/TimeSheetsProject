using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheets.Entities
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("FK_Customer")]
        public int CustomerId { get; set; }

        public List<Contract> Contracts { get; set; }

        [Required]
        [DisplayName("Hours spent")]
        public TimeSpan TotalHours { get; set; }

        [Required]
        [DisplayName("Total price")]
        public decimal TotalPrice { get; set; }

        [MaxLength(300)]
        public string Comment { get; set; }
    }
}