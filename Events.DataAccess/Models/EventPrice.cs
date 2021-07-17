using System;
using System.ComponentModel.DataAnnotations;

namespace Events.Repository.Models
{
    public class EventPrice
    {
        [Key]
        public int PriceId { get; set; }

        [Required]
        public int EventId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Currency { get; set; }
    }
}
