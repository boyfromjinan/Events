using System;
using System.ComponentModel.DataAnnotations;

namespace Events.Repository.Models
{
    public class Venue
    {
        [Key]
        public int VenueId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public string GeoLangitude { get; set; }
        public string GeoLatitude { get; set; }
    }
}