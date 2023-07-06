using Newtonsoft.Json;
namespace CineTix.Server.Models
{
    public class Movie
    {
        [JsonProperty("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Title { get; set; }

        public int Year { get; set; }

        public string Director { get; set; }

        public string Cast { get; set; }

        public string Genre { get; set; }

        public string Notes { get; set; }

        public Time[] RunningTimes { get; set; }
    }

    public class Time
    {
        public string[] mon { get; set; }

        public string[] tue { get; set; }

        public string[] wed { get; set; }

        public string[] thu { get; set; }

        public string[] fri { get; set; }

        public string[] sat { get; set; }

        public string[] sun { get; set; }
    }
}
