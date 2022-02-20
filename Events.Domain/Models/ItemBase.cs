namespace Events.Domain.Models
{
    using Newtonsoft.Json;

    public abstract class ItemBase
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}