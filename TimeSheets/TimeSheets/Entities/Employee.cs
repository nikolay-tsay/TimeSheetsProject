using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TimeSheets.Entities
{
    public class Employee 
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

        [Required]
        [DisplayName("Price/h")]
        public decimal Rate { get; set; }

        public List<Contract> Contracts { get; set; }
    }
}