using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Events.Repository.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        [Required]
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string MainDesc { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDesc { get; set; }
        public string Robots { get; set; }
        public bool Active { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsFreeEvent { get; set; }
        public Venue Venue { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public ICollection<EventPrice> EventPrices { get; set; }
    }
}
