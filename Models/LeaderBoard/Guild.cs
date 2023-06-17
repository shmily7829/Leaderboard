using System.Text.Json.Serialization;

namespace Leaderboard.Models.LeaderBoard
{
    public class Guild
    {
        [JsonPropertyName("allow_join")]
        public bool AllowJoin { get; set; }

        [JsonPropertyName("application_commands_enabled")]
        public bool ApplicationCommandsEnabled { get; set; }

        [JsonPropertyName("commands_prefix")]
        public string? CommandsPrefix { get; set; }

        [JsonPropertyName("icon")]
        public string? Icon { get; set; }

        [JsonPropertyName("invite_leaderboard")]
        public bool InviteLeaderboard { get; set; }

        [JsonPropertyName("leaderboard_url")]
        public string? LeaderboardUrl { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("premium")]
        public bool Premium { get; set; }
    }
}