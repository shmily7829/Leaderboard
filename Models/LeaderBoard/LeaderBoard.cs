using System.Text.Json.Serialization;

namespace Leaderboard.Models.LeaderBoard
{
    public class LeaderBoard
    {
        [JsonPropertyName("admin")]
        public bool Admin { get; set; }

        [JsonPropertyName("banner_url")]
        public string? BannerUrl { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("is_member")]
        public bool IsMember { get; set; }

        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("player")]
        public Player? Player { get; set; }

        [JsonPropertyName("guild")]
        public Guild Guild { get; set; }

        [JsonPropertyName("monetize_options")]
        public MonetizeOptions MonetizeOptions { get; set; }

        [JsonPropertyName("players")]
        public List<Player> Players { get; set; }

        public int MaxPlayersPerPage { get; private set; } = 100;
    }
}