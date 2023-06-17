using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaderboard.Models.UtopiaBot;

internal class PlayerExpRange
{
    public int Level { get; set; }
    public int CurrentUpgrateTime { get; set; }
    public ulong CurrentExp { get; set; }
    public ulong RequiredExp { get; set; }
    public ulong TotalExp { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"等級: {Level}");
        sb.AppendLine($"升到下一級時間: {CurrentUpgrateTime}分鐘");
        sb.AppendLine($"當前經驗: {CurrentExp}");
        sb.AppendLine($"第{Level}等經驗上限: {RequiredExp}");
        sb.AppendLine($"累積總經驗值: {TotalExp}");
        sb.AppendLine("==============================");
        Console.WriteLine(sb.ToString());
        return sb.ToString();
    }
}

