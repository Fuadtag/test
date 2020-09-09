using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day13.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Photo { get; set; }

        [Required]
        [Column(TypeName="money")]
        public decimal Price { get; set; }

        public ICollection<Contract> Contracts { get; set; }
    }
}
