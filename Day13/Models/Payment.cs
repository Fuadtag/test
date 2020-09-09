using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day13.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        public int ContractId { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Value { get; set; }

        public DateTime? PayDate { get; set; }

        [Required]
        public bool IsPaid { get; set; }

        public Contract Contract { get; set; }
    }
}
