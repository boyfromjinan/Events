namespace Events.Domain.Models
{
    using Newtonsoft.Json;

    public class Venue : CosmosItemBase
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("address1")]
        public string? Address1 { get; set; }

        [JsonProperty("address2")]
        public string? Address2 { get; set; }

        [JsonProperty("town")]
        public string? Town { get; set; }

        [JsonProperty("county")]
        public string? County { get; set; }

        [JsonProperty("post_code")]
        public string? PostCode { get; set; }

        [JsonProperty("country")]
        public string? Country { get; set; }
    }
}
