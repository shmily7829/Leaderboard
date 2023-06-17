using Leaderboard.Models.LeaderBoard;
using Leaderboard.Utils;
using System.Text;
using System.Text.Json;

namespace Leaderboard.Domain;

public class LeaderboardManager
{
    private const int FILTER_LEVEL = 3;
    private static readonly HttpClient _httpClient = new HttpClient();
    private static readonly PlayerLevelManager _levelManager = new PlayerLevelManager();
    private static List<Player> _players = new();

    public async Task Start()
    {
        await GetLeaderBoardPlayers();
        await FilterPlayersLevel();
        await CulclaterUtopiaLevel();

        string csvData = ConvertToCsv();
        FileHelper.SaveToCsvFile(csvData, "LeaderBoard.csv");
    }

    private async Task<List<Player>> GetLeaderBoardPlayers()
    {
        var leaderBoard = new LeaderBoard();
        int page = 0;
        string json = string.Empty;

        await Console.Out.WriteLineAsync($"get data started: {DateTime.Now}.");
        while (true)
        {
            var apiUrl = $@"https://mee6.xyz/api/plugins/levels/leaderboard/937992003415838761?page={page}";

            try
            {
                json = await GetApiData(apiUrl);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                break;
            }

            leaderBoard = JsonSerializer.Deserialize<LeaderBoard>(json);

            if (leaderBoard == null)
            {
                await Console.Out.WriteLineAsync("no data");
                break;
            }

            _players.AddRange(leaderBoard.Players);

            if (leaderBoard.Players.Count < leaderBoard.MaxPlayersPerPage)
            {
                await Console.Out.WriteLineAsync($"the data count less than {leaderBoard.MaxPlayersPerPage}.");
                break;
            }

            page += 1;
            await Task.Delay(500);
        }
        await Console.Out.WriteLineAsync($"get data finished: {DateTime.Now}.");
        await Console.Out.WriteLineAsync($"total player count: {_players.Count}");
        return _players;
    }

    private async Task<string> GetApiData(string url)
    {
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return content;
    }

    private async Task FilterPlayersLevel()
    {
        _players = _players.Where(c => c.Level >= FILTER_LEVEL).ToList();
        await Console.Out.WriteLineAsync($"more than lv3 player count: {_players.Count}");
    }

    private static async Task CulclaterUtopiaLevel()
    {
        foreach (var player in _players)
        {
            player.UtopiaLevel = await Task.Run(() => _levelManager.GetCurrentLevel((ulong)player.Xp));
        }
    }

    private string ConvertToCsv()
    {
        var csv = new StringBuilder();

        foreach (var player in _players)
        {
            csv.AppendLine($"{player.Id},{player.UserName},{player.Xp},{player.Level},{player.UtopiaLevel}");
        }

        return csv.ToString();
    }
}
