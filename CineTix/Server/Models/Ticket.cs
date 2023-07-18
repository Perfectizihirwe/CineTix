using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CineTix.Server.Models
{
    public class Ticket
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("movie")]
        public string Movie { get; set; }

        [JsonProperty("holderName")]

        public string HolderName { get; set; }

        [JsonProperty("holderEmail")]
        public string HolderEmail { get; set; }

        [JsonProperty("name")]
        public string Day { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("seat")]
        public Array Seat { get; set; }
    }
}
