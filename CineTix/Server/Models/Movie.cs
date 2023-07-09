using Newtonsoft.Json;
namespace CineTix.Server.Models
{
    public class Movie
    {
        [JsonProperty("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("year")]
		public int Year { get; set; }

		[JsonProperty("director")]
		public string Director { get; set; }

		[JsonProperty("cast")]
		public string Cast { get; set; }

		[JsonProperty("genre")]
		public string Genre { get; set; }

		[JsonProperty("notes")]
		public string Notes { get; set; }

        [JsonProperty("runningTimes")]
		public Time RunningTimes { get; set; }
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
