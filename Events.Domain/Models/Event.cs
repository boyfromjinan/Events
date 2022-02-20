namespace Events.Domain.Models
{
    using Newtonsoft.Json;

    public class Event : ItemBase
    {
        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }

        [JsonProperty("end_date")]
        public DateTime EndDate { get; set; }

        [JsonProperty("venue")]
        public Venue? Venue { get; set; }
    }
}