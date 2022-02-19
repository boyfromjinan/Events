namespace Events.Domain.Models
{
    using Newtonsoft.Json;

    public abstract class CosmosItemBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
