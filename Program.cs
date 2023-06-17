using Leaderboard.Domain;

namespace Leaderboard
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await new LeaderboardManager().Start();
        }
    }
}