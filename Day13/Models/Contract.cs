using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day13.Models
{
    public class Contract
    {
        public int Id { get; set; }

        [Required]
        public int PersonId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Month { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Cost { get; set; }

        public Person Person { get; set; }
        public Product Product { get; set; }

        public ICollection<Payment> Payments { get; set; }
    }
}
