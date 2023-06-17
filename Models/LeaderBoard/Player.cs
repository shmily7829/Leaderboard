using System.Text.Json.Serialization;

namespace Leaderboard.Models.LeaderBoard
{
    public class Player
    {
        [JsonPropertyName("avatar")]
        public string? Avatar { get; set; }

        [JsonPropertyName("detailed_xp")]
        public int[] DetailedXp { get; set; }

        [JsonPropertyName("discriminator")]
        public string Discriminator { get; set; }

        [JsonPropertyName("guild_id")]
        public string? GuildId { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("is_monetize_subscriber")]
        public bool IsMonetizeSubscriber { get; set; }

        [JsonPropertyName("level")]
        public int Level { get; set; }

        [JsonPropertyName("message_count")]
        public int MessageCount { get; set; }

        [JsonPropertyName("monetize_xp_boost")]
        public int MonetizeXpBoost { get; set; }

        [JsonPropertyName("username")]
        public string? UserName { get; set; }

        [JsonPropertyName("xp")]
        public int Xp { get; set; }

        public int UtopiaLevel { get; set; }
    }
}