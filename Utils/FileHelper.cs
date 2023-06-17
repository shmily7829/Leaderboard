using System.Text;

namespace Leaderboard.Utils;

public static class FileHelper
{
    public static void SaveToCsvFile(string csvData, string fileName)
    {
        string filePath = Path.Combine(@"D:\Temp", fileName);
        File.WriteAllText(filePath, csvData, Encoding.UTF8);
        Console.Out.WriteLineAsync($"data save success: {fileName}");
    }
}
