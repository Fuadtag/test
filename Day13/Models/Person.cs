using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Day13.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(50)]
        public string Phone { get; set; }

        public ICollection<Contract> Contracts { get; set; }
    }
}
