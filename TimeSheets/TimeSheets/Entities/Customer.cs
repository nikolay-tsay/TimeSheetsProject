using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TimeSheets.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public List<Contract> Contracts { get; set; }

        public List<Invoice> Invoices { get; set; }
    }
}