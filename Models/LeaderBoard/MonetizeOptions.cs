using System.Text.Json.Serialization;

namespace Leaderboard.Models.LeaderBoard
{
    public class MonetizeOptions
    {
        [JsonPropertyName("monetize_options")]
        public string? MonetizeOption { get; set; }

        [JsonPropertyName("display_plans")]
        public bool DisplayPlans { get; set; }

        [JsonPropertyName("showcase_subscribers")]
        public bool ShowcaseSubscribers { get; set; }
    }
}