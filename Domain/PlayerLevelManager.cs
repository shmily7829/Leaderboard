using Leaderboard.Models.UtopiaBot;

namespace Leaderboard.Domain;

internal class PlayerLevelManager
{
    private const int EXP_PER_MIN = 10;
    private static readonly int[] _coefficients = new int[10] { 1, 2, 4, 8, 12, 16, 32, 52, 64, 84 };
    private static readonly int _maxLevel = 100;
    private static ulong _currentExp;
    private static List<PlayerExpRange> _expRangeList = new List<PlayerExpRange>();

    public PlayerLevelManager()
    {
        _expRangeList = CreateLevelRange();
    }

    public int GetCurrentLevel(ulong mee6Exp)
    {
        //Level 等級、前一等級升級時間、當前等級升級時間、當前等級經驗、累積經驗值
        //依據升級公式建出等級表
        foreach (var expRange in _expRangeList)
        {
            if (mee6Exp >= expRange.CurrentExp && mee6Exp < expRange.TotalExp)
            {
                return expRange.Level;
            }
        }
        return 0;
    }

    private List<PlayerExpRange> CreateLevelRange()
    {
        //param = 1,2,4,8,12
        //(前一等級升級所需時間) + 10 * param = 升級所需時間(分鐘)
        //升級所需時間(分鐘) * 10 = 當前等級經驗值上限
        //當前等級經驗 + 當前經驗等級上限 = 累積經驗
        for (int level = 1; level <= _maxLevel; level++)
        {
            PlayerExpRange expRange = new PlayerExpRange();
            //當前等級
            expRange.Level = level;

            //升級需求時間
            expRange.CurrentUpgrateTime = GetUpgrateTime(level);

            //升級所需經驗
            expRange.RequiredExp = GetLevelExpCap(expRange.CurrentUpgrateTime);

            //總累積經驗值
            expRange.TotalExp = _currentExp + expRange.RequiredExp;

            //保存當前等級經驗
            expRange.CurrentExp = expRange.TotalExp - expRange.RequiredExp;

            expRange.ToString();
            _expRangeList.Add(expRange);

            //計算下一等級經驗
            _currentExp = expRange.TotalExp;
        }
        return _expRangeList;
    }

    private int GetUpgrateTime(int level)
    {
        if (level == 0)
        {
            return 0;
        }

        return GetUpgrateTime(level - 1) + EXP_PER_MIN * GetCoefficient(level);
    }

    private ulong GetLevelExpCap(int levelUpTime)
    {
        return Convert.ToUInt64(levelUpTime * EXP_PER_MIN);
    }

    private int GetCoefficient(int level)
    {
        int index = level / 10;
        if (index == 10)
            index -= 1;
        return _coefficients[index];
    }
}

